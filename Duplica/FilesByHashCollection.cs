using System.Collections.Generic;

namespace Duplica
{
	internal class FilesByHashCollection: FileGroupCollection<string>
	{
		public FilesByHashCollection(ScanContext context) : base(context)
		{
		}

		public int TotalFiles { get; private set; }
		public long TotalBytes { get; private set; }

		private void RecalculateTotals()
		{
			TotalFiles = 0;
			TotalBytes = 0;
			foreach (var kvp in FileGroups)
			{
				foreach (var fi in kvp.Value.FileInfos)
				{
					TotalFiles++;
					TotalBytes += fi.Length;
				}
			}
		}

		private void RemoveSingleFileGroups()
		{
			var hashesToRemove = new HashSet<string>();
			foreach (var kvp in FileGroups)
			{
				if (kvp.Value.Count <= 1) hashesToRemove.Add(kvp.Key);
			}
			foreach (var hash in hashesToRemove) FileGroups.Remove(hash);
		}

		private void RemoveDeletedFiles(bool refreshAll)
		{
			foreach (var kvp in FileGroups)
			{
				kvp.Value.RemoveDeletedFiles(refreshAll);
			}
		}

		public void Verify(bool refreshAll)
		{
			RemoveDeletedFiles(refreshAll);
			RemoveSingleFileGroups();
			RecalculateTotals();
		}
	}
}