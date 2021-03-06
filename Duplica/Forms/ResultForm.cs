﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Duplica.Forms
{
	partial class ResultForm : Form
	{
		private readonly FilesByHashCollection _filesByHash;
		private bool _frozen;

		public ResultForm(FilesByHashCollection filesByHash)
		{
			InitializeComponent();
			_filesByHash = filesByHash;
			_frozen = false;
		}

		private void PopulateForm()
		{
			_frozen = true;
			filesListView.Items.Clear();
			filesListView.Groups.Clear();
			filesListView.BeginUpdate();
			long totalWasted = 0;
			long nFiles = 0;
			foreach (var files in _filesByHash.GroupsInDescendingSizeOrder)
			{
				var wastedHere = ((files.Count - 1)*files.FileInfos[0].Length);
				totalWasted += wastedHere;
				var title = String.Format("{0} ({1:N2} KiB wasted)", files.Key, wastedHere/1024.0);
				var lvg = new ListViewGroup(files.Key.ToString(), title);
				var items = new List<ListViewItem>();
				foreach (var fi in files.FileInfos)
				{
					var lvi = new ListViewItem(new[]
					{
						fi.Name,
						fi.DirectoryName,
						String.Format("{0:N2} KiB", fi.Length/1024.0)
					}) {Tag = fi, ToolTipText = fi.Name};
					items.Add(lvi);
					nFiles ++;
				}
				foreach (var lvi in items.OrderBy((lvi) => lvi.ToolTipText.ToLowerInvariant()))
				{
					lvg.Items.Add(lvi);
					filesListView.Items.Add(lvi);
				}
				filesListView.Groups.Add(lvg);
			}
			filesListView.EndUpdate();
			Text = String.Format("{0} files, total wasted: {1:N2} KiB", nFiles, totalWasted/1024.0);
			_frozen = false;
		}


		private List<ListViewItem> GetCheckedItems()
		{
			return filesListView.Items.Cast<ListViewItem>().Where(lvi => lvi.Checked).ToList();
		}

		private void FilesListViewItemChecked(object sender, ItemCheckedEventArgs e)
		{
			if (_frozen) return;
			var lvis = GetCheckedItems();
			deleteFilesBtn.Text = String.Format("Delete {0} Items", lvis.Count);
			deleteFilesBtn.Enabled = (lvis.Count > 0);
		}

		private void DeleteFilesBtnClick(object sender, EventArgs e)
		{
			List<ListViewItem> lvis = GetCheckedItems();
			if (lvis.Count == 0) return;
			long sum = 0;
			foreach (ListViewItem lvi in lvis) sum += ((FileInfo) lvi.Tag).Length;

			if (MessageBox.Show(String.Format("Delete {0} files, freeing up {1:N2} KiB of space?\nThis can not be undone.", lvis.Count, sum/1024), "Delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
			{
				filesListView.BeginUpdate();
				foreach (ListViewItem lvi in lvis)
				{
					var fi = (FileInfo) lvi.Tag;
					lvi.Remove();

					try
					{
						fi.Delete();
						fi.Refresh();
						Debug.Print("Deleted: " + fi.FullName);
					}
					catch (Exception exc)
					{
						MessageBox.Show(String.Format("Error deleting {0}:\n{1}", fi.FullName, exc.Message));
					}
				}

				filesListView.EndUpdate();
				_filesByHash.Verify(false);
				PopulateForm();

				FilesListViewItemChecked(sender, null);
			}
		}

		private void SmartSelectBtnClick(object sender, EventArgs e)
		{
			using (Freeze())
			{
				foreach (ListViewGroup lvg in filesListView.Groups)
				{
					int i = 0;
					foreach (ListViewItem lvi in lvg.Items) lvi.Checked = ((i++) != 0);
				}
			}
			FilesListViewItemChecked(sender, null);
		}

		private void RefreshButtonClick(object sender, EventArgs e)
		{
			_filesByHash.Verify(true);
			PopulateForm();
		}

		private void ResultFormVisibleChanged(object sender, EventArgs e)
		{
			if (Visible)
			{
				PopulateForm();
			}
		}

		private void ExploreHereItemClick(object sender, EventArgs e)
		{
			if (filesListView.SelectedItems.Count > 0)
			{
				ListViewItem lvi = filesListView.SelectedItems[0];
				Process.Start("explorer.exe", "/select,\"" + (((FileInfo) lvi.Tag).FullName) + "\"");
			}
		}

		private void filesListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var item = filesListView.GetItemAt(e.X, e.Y);
			if (item != null)
			{
				Process.Start((((FileInfo)item.Tag).FullName));
			}
		}

		private void regexpSelectBox_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
			{
				var pattern = ((ToolStripTextBox)sender).Text;
				DoRegexpSelect(pattern);
			}
		}

		private void DoRegexpSelect(string pattern)
		{
			Regex regexp;
			try
			{
				regexp = new Regex(pattern, RegexOptions.IgnoreCase);
			}
			catch (Exception exc)
			{
				MessageBox.Show("Unable to compile regular expression: {0}", exc.Message);
				return;
			}
			var matches = filesListView.Items.Cast<ListViewItem>().Where((lvi) => regexp.IsMatch(((FileInfo) lvi.Tag).Name)).ToList();
			if (MessageBox.Show(string.Format("Select {0} items?", matches.Count), "Duplica", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				using (Freeze())
				{
					foreach (var listViewItem in matches)
					{
						listViewItem.Checked = true;
					}

				}
			}
		}

		private class _Freeze : IDisposable {
			private readonly ResultForm _resultForm;

			internal _Freeze(ResultForm resultForm)
			{
				_resultForm = resultForm;
				_resultForm._frozen = true;
				_resultForm.filesListView.BeginUpdate();
			}
			public void Dispose()
			{
				_resultForm.filesListView.EndUpdate();
				_resultForm._frozen = false;
			}
		}

		private _Freeze Freeze()
		{
			return new _Freeze(this);
		}
	}
}