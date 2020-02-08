using System;
using System.Collections.Generic;
using System.Text;

namespace WordSearchEngine
{
	public interface IDirectoryManager : IDisposable
	{
		int LoadFilesFromFolder(string pathToFolder);
		string GetTopSearchWordMatches(string wordToSearch);

	}
}
