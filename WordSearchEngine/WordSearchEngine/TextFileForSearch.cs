using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WordSearchEngine
{
	public class TextFileForSearch : ITextFileForSearch
	{
		public string FileName { get; set; }
		public string FileContent { get; set; }

		public int GetNumberOfMatches(string wordToSearch)
		{
			return Regex.Matches(FileContent, wordToSearch, RegexOptions.IgnoreCase).Count;
		}
	}
}
