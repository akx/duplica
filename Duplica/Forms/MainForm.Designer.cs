namespace Duplica.Forms
{
	partial class MainForm
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
			System.Windows.Forms.ContextMenuStrip dirCtxMenu;
			System.Windows.Forms.Label label1;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.addFolderItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dirFilterBox = new System.Windows.Forms.TextBox();
			this.fileFilterBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.AlgoCB = new System.Windows.Forms.ComboBox();
			this.extensionCB = new System.Windows.Forms.CheckBox();
			this.recurseCB = new System.Windows.Forms.CheckBox();
			this.toolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.StartButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.dirsListView = new System.Windows.Forms.ListView();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			dirCtxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			label1 = new System.Windows.Forms.Label();
			dirCtxMenu.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.toolStrip.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// dirCtxMenu
			// 
			dirCtxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFolderItem,
            this.removeFolderToolStripMenuItem});
			dirCtxMenu.Name = "contextMenuStrip1";
			dirCtxMenu.Size = new System.Drawing.Size(154, 48);
			dirCtxMenu.Opening += new System.ComponentModel.CancelEventHandler(this.DirCtxMenuOpening);
			// 
			// addFolderItem
			// 
			this.addFolderItem.Name = "addFolderItem";
			this.addFolderItem.Size = new System.Drawing.Size(153, 22);
			this.addFolderItem.Text = "Add Folder...";
			this.addFolderItem.Click += new System.EventHandler(this.AddFolderItemClick);
			// 
			// removeFolderToolStripMenuItem
			// 
			this.removeFolderToolStripMenuItem.Name = "removeFolderToolStripMenuItem";
			this.removeFolderToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.removeFolderToolStripMenuItem.Text = "Remove Folder";
			this.removeFolderToolStripMenuItem.Click += new System.EventHandler(this.RemoveFolderToolStripMenuItemClick);
			// 
			// label1
			// 
			label1.Location = new System.Drawing.Point(15, 25);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(105, 21);
			label1.TabIndex = 11;
			label1.Text = "Algorithm";
			label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
			this.splitContainer1.Panel1MinSize = 280;
			this.splitContainer1.Panel2Collapsed = true;
			this.splitContainer1.Size = new System.Drawing.Size(639, 574);
			this.splitContainer1.SplitterDistance = 302;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 1;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.toolStrip, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(639, 574);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.groupBox2, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 302);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(633, 269);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dirFilterBox);
			this.groupBox1.Controls.Add(this.fileFilterBox);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(12);
			this.groupBox1.Size = new System.Drawing.Size(310, 263);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filters";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(168, 18);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 19);
			this.label3.TabIndex = 9;
			this.label3.Text = "Directories";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 18);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 19);
			this.label2.TabIndex = 8;
			this.label2.Text = "Files";
			// 
			// dirFilterBox
			// 
			this.dirFilterBox.Location = new System.Drawing.Point(168, 40);
			this.dirFilterBox.Multiline = true;
			this.dirFilterBox.Name = "dirFilterBox";
			this.dirFilterBox.Size = new System.Drawing.Size(128, 208);
			this.dirFilterBox.TabIndex = 7;
			this.dirFilterBox.Text = "-*.svn\r\n-*.git\r\n-*.hg\r\n";
			// 
			// fileFilterBox
			// 
			this.fileFilterBox.Location = new System.Drawing.Point(14, 40);
			this.fileFilterBox.Multiline = true;
			this.fileFilterBox.Name = "fileFilterBox";
			this.fileFilterBox.Size = new System.Drawing.Size(128, 208);
			this.fileFilterBox.TabIndex = 7;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.AlgoCB);
			this.groupBox2.Controls.Add(this.extensionCB);
			this.groupBox2.Controls.Add(label1);
			this.groupBox2.Controls.Add(this.recurseCB);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(319, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(12);
			this.groupBox2.Size = new System.Drawing.Size(311, 263);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Settings";
			// 
			// AlgoCB
			// 
			this.AlgoCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.AlgoCB.FormattingEnabled = true;
			this.AlgoCB.Items.AddRange(new object[] {
            "MD5",
            "SHA1",
            "SHA256",
            "SHA512"});
			this.AlgoCB.Location = new System.Drawing.Point(126, 25);
			this.AlgoCB.Name = "AlgoCB";
			this.AlgoCB.Size = new System.Drawing.Size(165, 21);
			this.AlgoCB.TabIndex = 13;
			// 
			// extensionCB
			// 
			this.extensionCB.Checked = true;
			this.extensionCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.extensionCB.Location = new System.Drawing.Point(15, 80);
			this.extensionCB.Name = "extensionCB";
			this.extensionCB.Size = new System.Drawing.Size(197, 19);
			this.extensionCB.TabIndex = 12;
			this.extensionCB.Text = "Size groups honor extension";
			this.extensionCB.UseVisualStyleBackColor = true;
			// 
			// recurseCB
			// 
			this.recurseCB.Checked = true;
			this.recurseCB.CheckState = System.Windows.Forms.CheckState.Checked;
			this.recurseCB.Location = new System.Drawing.Point(15, 54);
			this.recurseCB.Name = "recurseCB";
			this.recurseCB.Size = new System.Drawing.Size(197, 20);
			this.recurseCB.TabIndex = 10;
			this.recurseCB.Text = "Recurse into subdirectories";
			this.recurseCB.UseVisualStyleBackColor = true;
			// 
			// toolStrip
			// 
			this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.StartButton,
            this.toolStripSeparator2});
			this.toolStrip.Location = new System.Drawing.Point(0, 0);
			this.toolStrip.Name = "toolStrip";
			this.toolStrip.Size = new System.Drawing.Size(639, 25);
			this.toolStrip.TabIndex = 4;
			this.toolStrip.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(109, 22);
			this.toolStripButton1.Text = "Add Directory...";
			this.toolStripButton1.Click += new System.EventHandler(this.AddFolderItemClick);
			// 
			// StartButton
			// 
			this.StartButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.StartButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.StartButton.Image = ((System.Drawing.Image)(resources.GetObject("StartButton.Image")));
			this.StartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.StartButton.Name = "StartButton";
			this.StartButton.Size = new System.Drawing.Size(55, 22);
			this.StartButton.Text = "Start";
			this.StartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.StartButton.Click += new System.EventHandler(this.StartButtonClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.dirsListView);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Location = new System.Drawing.Point(3, 28);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(633, 268);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Directories (drag && drop here!)";
			// 
			// dirsListView
			// 
			this.dirsListView.AllowDrop = true;
			this.dirsListView.ContextMenuStrip = dirCtxMenu;
			this.dirsListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dirsListView.GridLines = true;
			this.dirsListView.Location = new System.Drawing.Point(3, 16);
			this.dirsListView.Name = "dirsListView";
			this.dirsListView.Size = new System.Drawing.Size(627, 249);
			this.dirsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.dirsListView.TabIndex = 1;
			this.dirsListView.UseCompatibleStateImageBehavior = false;
			this.dirsListView.View = System.Windows.Forms.View.List;
			this.dirsListView.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirsListViewDragDrop);
			this.dirsListView.DragEnter += new System.Windows.Forms.DragEventHandler(this.DirsListViewDragEnter);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(639, 574);
			this.Controls.Add(this.splitContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(645, 600);
			this.Name = "MainForm";
			this.Text = "Duplica";
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DirsListViewDragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.DirsListViewDragEnter);
			dirCtxMenu.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.toolStrip.ResumeLayout(false);
			this.toolStrip.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.TextBox dirFilterBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox fileFilterBox;
		private System.Windows.Forms.CheckBox extensionCB;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ToolStripButton StartButton;
		private System.Windows.Forms.ToolStrip toolStrip;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolStripMenuItem removeFolderToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.ToolStripMenuItem addFolderItem;
		private System.Windows.Forms.ComboBox AlgoCB;
		private System.Windows.Forms.CheckBox recurseCB;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.ListView dirsListView;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
	}
}
