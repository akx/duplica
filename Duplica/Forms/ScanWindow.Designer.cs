/*
 * Date: 11.1.2010
 * Time: 22:25
 */
namespace Duplica.Forms
{
	partial class ScanWindow
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanWindow));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.statusProgress = new System.Windows.Forms.ProgressBar();
			this.textLabel = new System.Windows.Forms.Label();
			this.cancelButton = new System.Windows.Forms.Button();
			this.UITimer = new System.Windows.Forms.Timer(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.statusProgress, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textLabel, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 213);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// statusProgress
			// 
			this.statusProgress.Dock = System.Windows.Forms.DockStyle.Fill;
			this.statusProgress.Location = new System.Drawing.Point(13, 13);
			this.statusProgress.Name = "statusProgress";
			this.statusProgress.Size = new System.Drawing.Size(323, 34);
			this.statusProgress.TabIndex = 0;
			// 
			// textLabel
			// 
			this.textLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textLabel.Location = new System.Drawing.Point(13, 50);
			this.textLabel.Name = "textLabel";
			this.textLabel.Padding = new System.Windows.Forms.Padding(5);
			this.textLabel.Size = new System.Drawing.Size(323, 116);
			this.textLabel.TabIndex = 2;
			// 
			// cancelButton
			// 
			this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cancelButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelButton.Image")));
			this.cancelButton.Location = new System.Drawing.Point(113, 169);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(123, 29);
			this.cancelButton.TabIndex = 1;
			this.cancelButton.Text = "Stop";
			this.cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
			// 
			// UITimer
			// 
			this.UITimer.Interval = 150;
			this.UITimer.Tick += new System.EventHandler(this.UIUpdateTimerTick);
			// 
			// ScanWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(349, 213);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ScanWindow";
			this.Text = "Scan in Progress...";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.ProgressBar statusProgress;
		private System.Windows.Forms.Timer UITimer;
		private System.Windows.Forms.Label textLabel;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}
