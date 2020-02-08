
namespace WordSearchEngine
{
	public interface ITextFileForSearch
	{
		string FileName { get; set; }
		string FileContent { get; set; }
		int GetNumberOfMatches(string wordToSearch, bool wholeWord);
	}
}
