using System.Collections.Generic;
using System.IO;

namespace Duplica
{
	internal class ScanContext
	{
		public readonly ScanOptions Options;
		public readonly SizeExtFileGroupCollection FileGroups;
		public readonly List<FileInfo> FoundFiles;
		public readonly FilesByHashCollection FilesByHash;
		private readonly FilterManager _fileFilterManager;
		private readonly FilterManager _dirFilterManager;

		public ScanContext(ScanOptions options)
		{
			FoundFiles = new List<FileInfo>();
			Options = options;
			FileGroups = new SizeExtFileGroupCollection(this);
			FilesByHash = new FilesByHashCollection(this);
			_fileFilterManager = new FilterManager(options.FileFilters);
			_dirFilterManager = new FilterManager(options.DirFilters);
		}

		public FilterManager FileFilter
		{
			get { return _fileFilterManager; }
		}

		public FilterManager DirFilter
		{
			get { return _dirFilterManager; }
		}
	}
}