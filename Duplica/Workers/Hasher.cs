using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;

namespace Duplica.Workers
{
	internal class Hasher : WorkPhase
	{
		private const int SmallFileThreshold = 10*1024*1024;
		private readonly Queue<FileGroup> _groupQueue = new Queue<FileGroup>();
		private readonly Queue<FileInfo> _fileQueue = new Queue<FileInfo>();

		private long _totalFiles;
		private long _processedFiles;
		private long _bytesProcessed;
		private long _bytesTotal;
		private int _dupesFound;
		private int _nForbidden;
		private string _lastFilename = String.Empty;


		public Hasher(ScanContext context) : base(context)
		{
		}

		public override string Name
		{
			get { return "Hashing files"; }
		}

		public override long TotalProgress
		{
			get { return _totalFiles; }
		}

		public override long CurrentProgress
		{
			get { return _processedFiles; }
		}

		public override String StatusText
		{
			get
			{
				double kbps = (_bytesProcessed/ElapsedSeconds)/1024.0;

				string current = String.Format("Now reading: {0}", _lastFilename);
				string stats = String.Format(
					"{0} size groups left.\n{1}/{2} files ({3:N2} / {4:N2} MB) processed\nDuplicates so far: {5}\nSpeed: {6:N2} KB/s\nUnable to hash: {7:N0}",
					_groupQueue.Count,
					_processedFiles, _totalFiles,
					_bytesProcessed/1024.0/1024.0, _bytesTotal/1024.0/1024.0,
					_dupesFound, kbps, _nForbidden
					);

				return current + "\n" + stats;
			}
		}

		private void HashFile(FileInfo fi)
		{
			using (var fs = fi.OpenRead())
			{
				var hasher = HashAlgorithm.Create(Context.Options.Algorithm);
				if (hasher == null) return;
				hasher.Initialize();
				byte[] hashBytes;
				_lastFilename = fi.Name;
				if (Context.Options.HashByteLimit > 0) // Hash only first N bytes
				{
					var buf = new byte[Math.Min(fi.Length, Context.Options.HashByteLimit)];
					int n = fs.Read(buf, 0, buf.Length);
					hashBytes = hasher.ComputeHash(buf, 0, n);
				}
				else if (fi.Length < SmallFileThreshold) // Read small files quickly
				{
					var buf = new byte[fi.Length];
					int n = fs.Read(buf, 0, buf.Length);
					hashBytes = hasher.ComputeHash(buf, 0, n);
				}
				else
				{
					hashBytes = hasher.ComputeHash(fs);
				}
				var hashStr = BitConverter.ToString(hashBytes).Replace("-", "");
				_dupesFound += (Context.FilesByHash.Add(hashStr, fi) ? 1 : 0);
				_bytesProcessed += fi.Length;
				_processedFiles ++;
			}
		}

		private bool Step()
		{
			if (_groupQueue.Count == 0)
			{
				return false;
			}
			if (_fileQueue.Count == 0)
			{
				foreach (var fileInfo in _groupQueue.Dequeue().FileInfos)
				{
					_fileQueue.Enqueue(fileInfo);
				}
			}
			else
			{
				var fi = _fileQueue.Dequeue();

				try
				{
					HashFile(fi);
				}
				catch (UnauthorizedAccessException)
				{
					_nForbidden ++;
				}
			}
			return true;
		}

		protected override void OnDoWork(DoWorkEventArgs e)
		{
			_totalFiles = 0;
			_processedFiles = 0;
			_bytesProcessed = 0;
			_bytesTotal = 0;
			_dupesFound = 0;
			_nForbidden = 0;
			Context.FileGroups.RemoveSingleMemberGroups();
			_totalFiles = 0;
			_bytesTotal = 0;
			foreach (var g in Context.FileGroups.GroupsInDescendingSizeOrder)
			{
				_groupQueue.Enqueue(g);
				_totalFiles += g.Count;
				_bytesTotal += g.TotalSize;
			}
			while (Step() && !CancellationPending)
			{
				// doing things.
			}
		}
	}
}