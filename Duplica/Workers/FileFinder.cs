using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

namespace Duplica.Workers
{
	class FileFinder: WorkPhase
	{
		private readonly Queue<string> _openPaths = new Queue<string>();
		private readonly List<FileInfo> _foundFiles = new List<FileInfo>();
		private int _nRejected;
		private int _nForbidden;
		private string _lastPath;


		public FileFinder(ScanContext context)
			: base(context)
		{
		}

		public override string Name
		{
			get { return "Finding files"; }
		}

		public override long TotalProgress
		{
			get { return 0; }
		}

		public override long CurrentProgress
		{
			get { return 0; }
		}

		public override string StatusText
		{
			get
			{
				{
					return
						String.Format("{0:N0} files found\n", _foundFiles.Count) +
						String.Format("{0:N0} files rejected by filters\n", _nRejected) +
						(_nForbidden > 0 ? String.Format("{0:N0} paths inaccessible\n", _nForbidden) : "") +
						String.Format("{0:N0} directories to go\n", _openPaths.Count) +
						(_lastPath != null ? String.Format("Last path visited: {0}", _lastPath) : "");
				}
			}
		}

		private bool Step()
		{
			if(_openPaths.Count > 0)
			{
				var path = _openPaths.Dequeue();
				var directoryInfo = new DirectoryInfo(path);
				
				try {
					if(Context.Options.Recurse) {				
						foreach(var sdi in directoryInfo.GetDirectories()) {
							if (Context.DirFilter.Match(sdi.Name))
							{
								_openPaths.Enqueue(sdi.FullName);
							}
							else _nRejected ++;
						}
					}
					
					foreach(var fi in directoryInfo.GetFiles()) {
						if (Context.FileFilter.Match(fi.Name))
						{
							_foundFiles.Add(fi);
						}
						else _nRejected ++;
					}
					_lastPath = path;
				} catch(UnauthorizedAccessException) {
					_nForbidden ++;
				} catch(FileNotFoundException) {
					_nForbidden ++;
				}
				return true;
			}
			return false;
		}

		protected override void OnDoWork(DoWorkEventArgs e)
		{
			foreach (var path in Context.Options.Paths)
			{
				_openPaths.Enqueue(path);
			}
			while (Step() && !CancellationPending)
			{
				// doing things.
			}
			Context.FoundFiles.Clear();
			Context.FoundFiles.AddRange(_foundFiles);
		}

	}
}
