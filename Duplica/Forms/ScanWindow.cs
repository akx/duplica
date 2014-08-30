using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Duplica.Workers;

namespace Duplica.Forms
{
	partial class ScanWindow : Form
	{
		private readonly List<WorkPhase> _phases = new List<WorkPhase>();
		private int _currentPhaseIndex;
		private readonly ScanContext _context;
		private double _lastLeftSecsEst;
		private readonly Bitmap _iconBitmap;
		private readonly Graphics _iconGraphics;

		public ScanWindow(ScanContext context)
		{
			InitializeComponent();
			_context = context;
			_iconBitmap = new Bitmap(16, 16, PixelFormat.Format32bppArgb);
			_iconGraphics = Graphics.FromImage(_iconBitmap);
			_iconGraphics.CompositingQuality = CompositingQuality.HighQuality;
			_iconGraphics.InterpolationMode = InterpolationMode.High;
			_iconGraphics.SmoothingMode = SmoothingMode.AntiAlias;
			_phases.Add(new FileFinder(_context));
			_phases.Add(new Grouper(_context));
			_phases.Add(new Hasher(_context));
			Shown += (sender, args) => BeginPhase();
			Closing += (sender, args) =>
			{
				UITimer.Enabled = false;
				if (CurrentPhase != null) CurrentPhase.CancelAsync();
			};
		}


		private void BeginPhase()
		{
			if (!Visible) return;
			var phase = CurrentPhase;
			Debug.Print("Starting phase: {0}", phase);
			if (phase == null)
			{
				FinishScanOperation();
				return;
			}
			UITimer.Enabled = true;
			phase.RunWorkerCompleted += PhaseCompleted;
			phase.Start();
			_lastLeftSecsEst = 0;
		}

		private WorkPhase CurrentPhase
		{
			get
			{
				if (_currentPhaseIndex < 0 || _currentPhaseIndex >= _phases.Count) return null;
				return _phases[_currentPhaseIndex];
			}
		}

		private void PhaseCompleted(object sender, RunWorkerCompletedEventArgs runWorkerCompletedEventArgs)
		{
			_currentPhaseIndex++;
			BeginPhase();
		}


		private void UIUpdateTimerTick(object sender, EventArgs e)
		{
			var phase = CurrentPhase;
			if (phase == null) return;
			string phaseName = phase.Name;
			long totalProgress = phase.TotalProgress;
			long currentProgress = phase.CurrentProgress;

			if (totalProgress > 0)
			{
				double progress = currentProgress/(double) totalProgress;
				phaseName = phaseName + String.Format(" - {0:N1}%", progress*100.0);
				if (progress > 0.005)
				{
					var currSecs = phase.ElapsedSeconds;
					var totalSecs = currSecs/progress;
					var newLeftSecs = totalSecs - currSecs;
					_lastLeftSecsEst = (_lastLeftSecsEst*15.0 + newLeftSecs)/16.0;
					TimeSpan leftTimeSpan = TimeSpan.FromSeconds(_lastLeftSecsEst);
					if (leftTimeSpan.TotalHours >= 1)
					{
						phaseName += String.Format(" - ETA {0:00}:{1:00}:{2:00}", leftTimeSpan.TotalHours, leftTimeSpan.Minutes, leftTimeSpan.Seconds);
					}
					else
					{
						phaseName += String.Format(" - ETA {0:00}:{1:00}", leftTimeSpan.Minutes, leftTimeSpan.Seconds);
					}
				}
				UpdateIcon(true, (float) progress);
				statusProgress.Style = ProgressBarStyle.Continuous;
				statusProgress.Maximum = 10000;
				statusProgress.Value = (int) (progress*10000);
			}
			else
			{
				statusProgress.Style = ProgressBarStyle.Marquee;
				UpdateIcon(false, (DateTime.Now.Second + DateTime.Now.Millisecond/1000.0f)/15.0f);
			}

			Text = String.Format("{0}/{1}: {2}", _currentPhaseIndex + 1, _phases.Count, phaseName);
			textLabel.Text = phaseName + "\n" + phase.StatusText;
		}

		private void CancelButtonClick(object sender, EventArgs e)
		{
			FinishScanOperation();
		}


		private void FinishScanOperation()
		{
			Close();
			ShowResultDialog();
		}

		private void ShowResultDialog()
		{
			_context.FilesByHash.Verify(false);
			if (_context.FilesByHash.GroupCount == 0)
			{
				return;
			}
			var rf = new ResultForm(_context.FilesByHash);
			rf.Show();
		}

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool DestroyIcon(IntPtr handle);

		private void UpdateIcon(bool definite, float progress)
		{
			_iconGraphics.Clear(Color.Transparent);
			if (definite)
			{
				progress = Math.Max(1, Math.Min(progress, 0));
				float angle2 = progress*360;
				_iconGraphics.FillEllipse(Brushes.Black, 0, 0, _iconBitmap.Width - 1, _iconBitmap.Height - 1);
				_iconGraphics.FillPie(Brushes.Lime, 0, 0, _iconBitmap.Width - 1, _iconBitmap.Height - 1, 0, angle2);
			}
			else
			{
				_iconGraphics.FillEllipse(Brushes.Aqua, 11, ((int) Math.Round(14 - Math.Abs(Math.Sin(progress*10))*12)) - 1, 3, 3);
				_iconGraphics.FillEllipse(Brushes.Aqua, 4, ((int) Math.Round(14 - Math.Abs(Math.Sin(progress*10 + 5))*12)) - 1, 3, 3);
			}
			DestroyIcon(Icon.Handle);
			Icon = Icon.FromHandle(_iconBitmap.GetHicon());
		}
	}
}