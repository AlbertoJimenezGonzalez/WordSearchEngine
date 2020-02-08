using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchEngine
{
	public class DirectoryManager : IDirectoryManager
	{
		private readonly List<ITextFileForSearch> filesInFolder;

		public DirectoryManager()
		{
			filesInFolder = new List<ITextFileForSearch>();
		}

		public int LoadFilesFromFolder(string pathToFolder)
		{
			return 0;
		}

		public string GetTopSearchWordMatches(string wordToSearch)
		{
			throw new NotImplementedException();
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
