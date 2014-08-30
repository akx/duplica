using System.IO;

namespace Duplica
{

	struct SizeExtPair
	{
		public readonly long Size;
		public readonly string Ext;

		public SizeExtPair(long size, string ext)
		{
			Size = size;
			Ext = ext;
		}

		public override int GetHashCode()
		{
			return Size.GetHashCode() ^ Ext.GetHashCode();
		}
	};

	internal class SizeExtFileGroupCollection: FileGroupCollection<SizeExtPair>
	{
		public SizeExtFileGroupCollection(ScanContext context) : base(context)
		{
		}

		public void Add(FileInfo fi)
		{
			var sep = new SizeExtPair(fi.Length, (Context.Options.ExtensionGroups ? fi.Extension.ToLowerInvariant() : "*"));
			Add(sep, fi);
		}


	}
}