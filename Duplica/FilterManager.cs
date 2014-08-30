using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Duplica
{
	internal class FilterManager
	{
		private delegate bool FilterDelegate(string name);

		private readonly List<FilterDelegate> _filterDelegates = new List<FilterDelegate>();

		private enum FilterMode
		{
			Unknown,
			Allow,
			Exclude
		};

		public FilterManager(IEnumerable<string> filterStrings = null)
		{
			if (filterStrings != null)
			{
				foreach (var filterString in filterStrings)
				{
					AddFilter(filterString);
				}
			}
		}

		private static FilterDelegate CompileFilter(string filterStr)
		{
			var mode = FilterMode.Unknown;
			filterStr = filterStr.Trim();
			if (filterStr == "") return null;
			if (filterStr.StartsWith("+"))
			{
				mode = FilterMode.Allow;
				filterStr = filterStr.Substring(1);
			}
			else if (filterStr.StartsWith("-"))
			{
				mode = FilterMode.Exclude;
				filterStr = filterStr.Substring(1);
			}
			if (mode == FilterMode.Unknown)
			{
				throw new ArgumentException("Filter string invalid: " + filterStr);
			}
			if (filterStr.StartsWith("*"))
			{
				var f = filterStr.Substring(1).ToLower();
				if (mode == FilterMode.Allow) return name => name.ToLower().Contains(f);
				if (mode == FilterMode.Exclude) return name => !name.ToLower().Contains(f);
			}
			else
			{
				var r = new Regex(filterStr, RegexOptions.IgnoreCase);
				if (mode == FilterMode.Allow) return name => r.Match(name).Success;
				if (mode == FilterMode.Exclude) return name => !r.Match(name).Success;
			}
			return null;
		}

		public bool AddFilter(string filterString)
		{
			var fd = CompileFilter(filterString);
			if (fd != null)
			{
				_filterDelegates.Add(fd);
				return true;
			}
			return false;
		}

		public bool Match(string fileName)
		{
			return _filterDelegates.Count == 0 || _filterDelegates.All(fd => fd(fileName));
		}
	}
}