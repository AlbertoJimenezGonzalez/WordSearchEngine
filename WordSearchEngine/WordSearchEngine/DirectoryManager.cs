using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WordSearchEngine
{
	public class DirectoryManager : IDirectoryManager
	{
		private readonly List<ITextFileForSearch> filesInFolder;
		private readonly int topElements;

		public DirectoryManager(int topNumber)
		{
			filesInFolder = new List<ITextFileForSearch>();
			topElements = topNumber;
		}

		public int LoadFilesFromFolder(string pathToFolder)
		{
			if (Directory.Exists(pathToFolder))
			{
				foreach (var file in Directory.EnumerateFiles(pathToFolder))
				{
					var fileContent = File.ReadAllText(file);
					var fileName = file.Replace(pathToFolder, null, StringComparison.InvariantCultureIgnoreCase);
					ITextFileForSearch fileInFolder = TextFileForSearchFactory.CreateTextFileForSearch(fileName, fileContent);
					filesInFolder.Add(fileInFolder);
				}
			}

			return filesInFolder.Count;
		}

		public string GetTopSearchWordMatches(string wordToSearch)
		{
			var results = (from file in filesInFolder
						   let num = file.GetNumberOfMatches(wordToSearch, true)
						   where num > 0
						   select new { Name = file.FileName, Number = num })
						 .OrderByDescending(x => x.Number)
						 .Take(topElements).ToList();

			var sb = new StringBuilder();

			if (results.Count > 0)
			{
				foreach (var element in results)
				{
					sb.AppendLine($"{element.Name} : {element.Number} ocurrences.");
				}

				results.Clear();
			}
			else
				sb.AppendLine("no matches found");

			return sb.ToString();
		}

		public void Dispose()
		{
			Dispose(true);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				filesInFolder.Clear();
			}
		}
	}
}
