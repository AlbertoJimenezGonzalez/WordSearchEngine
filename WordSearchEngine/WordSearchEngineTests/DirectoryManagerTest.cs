using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using WordSearchEngine;

namespace WordSearchEngineTests
{
	public class DirectoryManagerTest
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void DirectoryManagerShouldReturn0FilesReadWhenDirectoryIsEmpty()
		{
			//Arrange
			var now = DateTime.Now;
			string dirPath = @"C:\EmptyFolder_" + now.ToString("yyyyMMdd_hhmmss");
			if (Directory.Exists(dirPath))
			{
				Directory.Delete(dirPath, true);
			}
			Directory.CreateDirectory(dirPath);
			IDirectoryManager directoryManager = new DirectoryManager();

			//Act
			var numFiles = directoryManager.LoadFilesFromFolder(dirPath);

			//Assert
			Assert.AreEqual(0, numFiles);

			//Cleaning the environment
			if (Directory.Exists(dirPath))
			{
				Directory.Delete(dirPath, true);
			}
		}
	}
}
