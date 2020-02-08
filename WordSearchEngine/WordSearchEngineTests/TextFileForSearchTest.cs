using NUnit.Framework;
using WordSearchEngine;

namespace WordSearchEngineTests
{
	public class TextFileForSearchTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void EmptyFileContentShoudGiveZeroMatches()
		{
			//Arrange
			ITextFileForSearch textFileForSearch = new TextFileForSearch();
			textFileForSearch.FileContent = string.Empty;
			textFileForSearch.FileName = string.Empty;

			//Act
			var result = textFileForSearch.GetNumberOfMatches("hola");

			//Assert
			Assert.AreEqual(0, result);
		}
	}
}