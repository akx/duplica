using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Duplica
{
	internal abstract class FileGroupCollection<TGroupKey>
	{
		protected readonly ScanContext Context;
		protected readonly Dictionary<TGroupKey, FileGroup> FileGroups = new Dictionary<TGroupKey, FileGroup>();

		public int GroupCount
		{
			get { return FileGroups.Count; }
		}

		public IEnumerable<FileGroup> GroupsInDescendingSizeOrder
		{
			get { return FileGroups.Values.OrderByDescending(fg => fg.TotalSize); }
		}

		protected FileGroupCollection(ScanContext context)
		{
			Context = context;
		}

		public void RemoveSingleMemberGroups()
		{
			var keysToRemove = (from kvp in FileGroups where kvp.Value.Count == 1 select kvp.Key).ToList();
			foreach (var size in keysToRemove) FileGroups.Remove(size);
		}

		public bool Add(TGroupKey key, FileInfo file)
		{
			bool isNewGroup = false;
			if (!FileGroups.ContainsKey(key))
			{
				FileGroups[key] = new FileGroup(file.Length, key);
				isNewGroup = true;
			}
			FileGroups[key].Add(file);
			return isNewGroup;
		}
	}
}