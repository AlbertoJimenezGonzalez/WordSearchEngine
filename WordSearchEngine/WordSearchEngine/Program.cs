using System;

namespace WordSearchEngine
{
	class Program
	{
		private static readonly IDirectoryManager directoryManager = new DirectoryManager(10);

		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Please add a directory path as argument");
			}
			else
			{
				var directoryToLoad = args[0];
				var numberOfFilesLoaded = directoryManager.LoadFilesFromFolder(directoryToLoad);
				Console.WriteLine($"{numberOfFilesLoaded} files read in directory {directoryToLoad}");
				Console.WriteLine();
				ShowSearchOption();
			}
		}

		static void ShowSearchOption()
		{
			var goOn = true;
			while (goOn)
			{
				Console.Write("Search> ");
				var wordToFind = Console.ReadLine();
				if (wordToFind != "")
				{
					var result = directoryManager.GetTopSearchWordMatches(wordToFind);
					Console.WriteLine(result);
				}
				else
					goOn = false;
			}
		}
	}
}
