using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Duplica
{
	internal class ScanOptions
	{
		private readonly string _algorithm;
		private readonly List<string> _dirFilters;
		private readonly bool _extensionGroups;
		private readonly List<string> _fileFilters;
		private readonly List<String> _paths;
		private readonly bool _recurse;
		private readonly int _hashByteLimit;

		public ScanOptions(IEnumerable<string> paths, IEnumerable<string> fileFilters, IEnumerable<string> dirFilters, bool recurse, bool extensionGroups, string algorithm, int hashByteLimit)
		{
			_paths = new List<string>(paths);
			_fileFilters = new List<string>(fileFilters);
			_dirFilters = new List<string>(dirFilters);
			_recurse = recurse;
			_extensionGroups = extensionGroups;
			_algorithm = algorithm;
			_hashByteLimit = hashByteLimit;
			try
			{
				HashAlgorithm ha = HashAlgorithm.Create(algorithm);
				if (ha == null) throw new ArgumentException("Could not initialize hasher");
			}
			catch (Exception exc)
			{
				throw new ArgumentException("Algorithm is invalid: " + exc.Message);
			}
		}

		public List<string> Paths
		{
			get { return _paths; }
		}

		public bool Recurse
		{
			get { return _recurse; }
		}

		public bool ExtensionGroups
		{
			get { return _extensionGroups; }
		}

		public string Algorithm
		{
			get { return _algorithm; }
		}

		public List<string> FileFilters
		{
			get { return _fileFilters; }
		}

		public List<string> DirFilters
		{
			get { return _dirFilters; }
		}

		public int HashByteLimit
		{
			get { return _hashByteLimit; }
		}
	}
}