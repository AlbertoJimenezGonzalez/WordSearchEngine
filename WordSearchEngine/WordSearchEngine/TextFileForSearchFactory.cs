using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchEngine
{
	public static class TextFileForSearchFactory
	{
		public static TextFileForSearch CreateTextFileForSearch(string fileName, string Content)
		{
			var textFile = new TextFileForSearch()
			{
				FileContent = Content,
				FileName = fileName
			};

			return textFile;
		}
	}
}
