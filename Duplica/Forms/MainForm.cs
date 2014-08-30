using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Duplica.Forms
{
	public partial class MainForm : Form
	{
		public MainForm(IEnumerable<string> args)
		{
			InitializeComponent();
			AlgoCB.SelectedIndex = 0;
			foreach (var arg in args)
			{
				if (Directory.Exists(arg))
				{
					dirsListView.Items.Add(arg);
				}
			}
		}

		
		private void AddFolder(string path)
		{
			if(!Directory.Exists(path)) return;
			if(dirsListView.Items.IndexOfKey(path) < 0) dirsListView.Items.Add(path, path, null);
		}
		
		void AddFolderItemClick(object sender, EventArgs e)
		{
			if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				AddFolder(folderBrowserDialog.SelectedPath);
			}
		}
		
		void DirCtxMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			removeFolderToolStripMenuItem.Enabled=(dirsListView.SelectedIndices.Count > 0);
		}
		
		void RemoveFolderToolStripMenuItemClick(object sender, EventArgs e)
		{
			foreach(ListViewItem lvi in dirsListView.SelectedItems)
			{
				lvi.Remove();
			}
		}
		
		void StartButtonClick(object sender, EventArgs e)
		{
			var paths = (from ListViewItem lvi in dirsListView.Items select lvi.Text).ToList();
			if(paths.Count == 0)
			{
				MessageBox.Show("No directories set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			
			var context = new ScanContext(new ScanOptions(
				paths.ToArray(),
				fileFilterBox.Text.Split('\n'),
				dirFilterBox.Text.Split('\n'),
				recurseCB.Checked,
				extensionCB.Checked,
				(string)AlgoCB.SelectedItem
			));
			var scanWindow = new ScanWindow(context);
			scanWindow.Show();
		}
		
		void DirsListViewDragDrop(object sender, DragEventArgs e)
		{
			if (!e.Data.GetDataPresent(DataFormats.FileDrop, false)) return;
			foreach(var fpath in (String[])e.Data.GetData(DataFormats.FileDrop, false))
			{
				AddFolder(fpath);
			}
		}


		void DirsListViewDragEnter(object sender, DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop, false))
			{
				e.Effect = DragDropEffects.All;
			}
		}
		
	}
}
