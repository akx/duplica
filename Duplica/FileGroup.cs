using System.Collections.Generic;
using System.IO;

namespace Duplica
{
	internal class FileGroup
	{
		public readonly object Key;
		public readonly long FileSize;
		private readonly List<FileInfo> _fileInfos = new List<FileInfo>();

		public long Count
		{
			get { return _fileInfos.Count; }
		}

		public long TotalSize
		{
			get { return FileSize*_fileInfos.Count; }
		}

		public List<FileInfo> FileInfos
		{
			get { return _fileInfos; }
		}

		public FileGroup(long fileSize, object key)
		{
			FileSize = fileSize;
			Key = key;
		}

		public void Add(FileInfo fileInfo)
		{
			_fileInfos.Add(fileInfo);
		}

		public void RemoveDeletedFiles(bool refresh=false)
		{
			var fisToRemove = new List<FileInfo>();
			foreach (var fi in _fileInfos)
			{
				if (refresh) fi.Refresh();
				if (!fi.Exists) fisToRemove.Add(fi);
			}
			foreach (var fi in fisToRemove) _fileInfos.Remove(fi);
		}
	}
}