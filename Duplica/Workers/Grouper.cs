using System;
using System.ComponentModel;

namespace Duplica.Workers
{
	internal class Grouper : WorkPhase
	{
		private int _fileIndex;

		public Grouper(ScanContext context) : base(context)
		{
		}

		public override string Name
		{
			get { return "Grouping files"; }
		}

		public override string StatusText
		{
			get { return String.Format("{0}/{1} files processed\n{2} groups thus far", _fileIndex, Context.FoundFiles.Count, Context.FileGroups.GroupCount); }
		}

		public override long TotalProgress
		{
			get { return Context.FoundFiles.Count; }
		}

		public override long CurrentProgress
		{
			get { return _fileIndex; }
		}

		private bool Tick()
		{
			if (_fileIndex >= Context.FoundFiles.Count) return false;
			Context.FileGroups.Add(Context.FoundFiles[_fileIndex]);
			_fileIndex++;
			return true;
		}

		protected override void OnDoWork(DoWorkEventArgs e)
		{
			while (Tick())
			{
				// Doing things!
			}
		}
	}
}