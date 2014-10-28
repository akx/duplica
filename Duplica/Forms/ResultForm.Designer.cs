/*
 * Created by SharpDevelop.
 * User: X
 * Date: 27.10.2009
 * Time: 0:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Duplica.Forms
{
	partial class ResultForm
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
			System.Windows.Forms.ColumnHeader NameHdr;
			System.Windows.Forms.ColumnHeader PathHdr;
			System.Windows.Forms.ColumnHeader SizeHdr;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResultForm));
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.refreshButton = new System.Windows.Forms.ToolStripButton();
			this.smartSelectBtn = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteFilesBtn = new System.Windows.Forms.ToolStripButton();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.filesListView = new System.Windows.Forms.ListView();
			this.listMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.exploreHereItem = new System.Windows.Forms.ToolStripMenuItem();
			this.regexpSelectBox = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			NameHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			PathHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			SizeHdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.listMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// NameHdr
			// 
			NameHdr.Text = "Name";
			NameHdr.Width = 218;
			// 
			// PathHdr
			// 
			PathHdr.Text = "Path";
			PathHdr.Width = 289;
			// 
			// SizeHdr
			// 
			SizeHdr.Text = "Size";
			SizeHdr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			SizeHdr.Width = 91;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 566);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(888, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshButton,
            this.toolStripSeparator2,
            this.smartSelectBtn,
            this.toolStripLabel1,
            this.regexpSelectBox,
            this.toolStripSeparator1,
            this.deleteFilesBtn});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(888, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// refreshButton
			// 
			this.refreshButton.Image = ((System.Drawing.Image)(resources.GetObject("refreshButton.Image")));
			this.refreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.refreshButton.Name = "refreshButton";
			this.refreshButton.Size = new System.Drawing.Size(66, 22);
			this.refreshButton.Text = "Refresh";
			this.refreshButton.Click += new System.EventHandler(this.RefreshButtonClick);
			// 
			// smartSelectBtn
			// 
			this.smartSelectBtn.Image = ((System.Drawing.Image)(resources.GetObject("smartSelectBtn.Image")));
			this.smartSelectBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.smartSelectBtn.Name = "smartSelectBtn";
			this.smartSelectBtn.Size = new System.Drawing.Size(105, 22);
			this.smartSelectBtn.Text = "Select N-1/Grp";
			this.smartSelectBtn.Click += new System.EventHandler(this.SmartSelectBtnClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// deleteFilesBtn
			// 
			this.deleteFilesBtn.Image = ((System.Drawing.Image)(resources.GetObject("deleteFilesBtn.Image")));
			this.deleteFilesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.deleteFilesBtn.Name = "deleteFilesBtn";
			this.deleteFilesBtn.Size = new System.Drawing.Size(133, 22);
			this.deleteFilesBtn.Text = "Delete Selected Files";
			this.deleteFilesBtn.Click += new System.EventHandler(this.DeleteFilesBtnClick);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.filesListView, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(888, 541);
			this.tableLayoutPanel1.TabIndex = 3;
			// 
			// filesListView
			// 
			this.filesListView.CheckBoxes = true;
			this.filesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            NameHdr,
            PathHdr,
            SizeHdr});
			this.filesListView.ContextMenuStrip = this.listMenu;
			this.filesListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.filesListView.FullRowSelect = true;
			this.filesListView.GridLines = true;
			this.filesListView.Location = new System.Drawing.Point(0, 0);
			this.filesListView.Margin = new System.Windows.Forms.Padding(0);
			this.filesListView.Name = "filesListView";
			this.filesListView.Size = new System.Drawing.Size(888, 541);
			this.filesListView.TabIndex = 2;
			this.filesListView.UseCompatibleStateImageBehavior = false;
			this.filesListView.View = System.Windows.Forms.View.Details;
			this.filesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.FilesListViewItemChecked);
			this.filesListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.filesListView_MouseDoubleClick);
			// 
			// listMenu
			// 
			this.listMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exploreHereItem});
			this.listMenu.Name = "listMenu";
			this.listMenu.Size = new System.Drawing.Size(190, 26);
			// 
			// exploreHereItem
			// 
			this.exploreHereItem.Image = ((System.Drawing.Image)(resources.GetObject("exploreHereItem.Image")));
			this.exploreHereItem.Name = "exploreHereItem";
			this.exploreHereItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.exploreHereItem.Size = new System.Drawing.Size(189, 22);
			this.exploreHereItem.Text = "Explore Here...";
			this.exploreHereItem.Click += new System.EventHandler(this.ExploreHereItemClick);
			// 
			// regexpSelectBox
			// 
			this.regexpSelectBox.Name = "regexpSelectBox";
			this.regexpSelectBox.Size = new System.Drawing.Size(100, 25);
			this.regexpSelectBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.regexpSelectBox_KeyUp);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(98, 22);
			this.toolStripLabel1.Text = "Select by Regexp:";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// ResultForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(888, 588);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.statusStrip1);
			this.Name = "ResultForm";
			this.Text = "ResultForm";
			this.VisibleChanged += new System.EventHandler(this.ResultFormVisibleChanged);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.listMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem exploreHereItem;
		private System.Windows.Forms.ContextMenuStrip listMenu;
		private System.Windows.Forms.ToolStripButton refreshButton;
		private System.Windows.Forms.ToolStripButton smartSelectBtn;
		private System.Windows.Forms.ToolStripButton deleteFilesBtn;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ListView filesListView;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox regexpSelectBox;
	}
}
