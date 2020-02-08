using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchEngine
{
	public interface ITextFileForSearch
	{
		string FileName { get; set; }
		string FileContent { get; set; }
		int GetNumberOfMatches(string wordToSearch);
	}
}
