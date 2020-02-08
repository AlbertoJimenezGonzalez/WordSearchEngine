using NUnit.Framework;
using WordSearchEngine;

namespace WordSearchEngineTests
{
	public class TextFileForSearchTest
	{
		ITextFileForSearch textFileForSearch = null;
		
		[SetUp]
		public void Setup()
		{
			textFileForSearch = TextFileForSearchFactory.CreateTextFileForSearch(string.Empty, string.Empty);
		}

		[Test]
		public void EmptyFileContentShoudGiveZeroMatches()
		{
			//Arrange
			textFileForSearch.FileContent = FakeContentFile.GetEmptyContentFile();

			//Act
			var result = textFileForSearch.GetNumberOfMatches("hola",true);

			//Assert
			Assert.AreEqual(0, result);
		}

		[Test]
		public void NonEmptyFileContentWithNoMatchesShouldGiveZeroMatches()
		{
			//Arrange
			textFileForSearch.FileContent = FakeContentFile.GetContentFile();

			//Act
			var result = textFileForSearch.GetNumberOfMatches("hola",true);

			//Assert
			Assert.AreEqual(0, result);
		}

		[Test]
		public void NonEmptyFileContentWith3MatchesShouldGive3Matches()
		{
			//Arrange
			textFileForSearch.FileContent = FakeContentFile.GetContentFile();

			//Act
			var result = textFileForSearch.GetNumberOfMatches("prueba",true);

			//Assert
			Assert.AreEqual(3, result);
		}

		[Test]
		public void NonEmptyFileContentWith2MatchesShouldGive2MatchesIfWholeWordIsNotConsidered()
		{
			//Arrange
			textFileForSearch.FileContent = FakeContentFile.GetContentFile();

			//Act
			var result = textFileForSearch.GetNumberOfMatches("debe",false);

			//Assert
			Assert.AreEqual(2, result);
		}

		[Test]
		public void NonEmptyFileContentWith2MatchesShouldGive1MatchIfWholeWordIsConsidered()
		{
			//Arrange
			textFileForSearch.FileContent = FakeContentFile.GetContentFile();

			//Act
			var result = textFileForSearch.GetNumberOfMatches("debe", true);

			//Assert
			Assert.AreEqual(1, result);
		}
	}
}