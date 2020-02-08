using System.Text.RegularExpressions;

namespace WordSearchEngine
{
	public class TextFileForSearch : ITextFileForSearch
	{
		public string FileName { get; set; }
		public string FileContent { get; set; }

		public int GetNumberOfMatches(string wordToSearch, bool wholeWord)
		{
			var pattern = wholeWord ? @"\b" + wordToSearch + @"\b" : wordToSearch;
			return Regex.Matches(FileContent, pattern, RegexOptions.IgnoreCase).Count;
		}
	}
}
