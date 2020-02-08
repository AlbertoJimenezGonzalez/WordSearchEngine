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

		private void DeleteDirectory(string dirPath)
		{
			if (Directory.Exists(dirPath))
			{
				Directory.Delete(dirPath, true);
			}
		}

		private string SetEnvironment()
		{
			var now = DateTime.Now;
			string dirPath = @"C:\EmptyFolder_" + now.ToString("yyyyMMdd_hhmmss");
			DeleteDirectory(dirPath);
			Directory.CreateDirectory(dirPath);
			return dirPath;
		}

		private void CreateFiles(string path, int numberOfFiles)
		{
			for (int i = 0; i < numberOfFiles; i++)
			{
				var fileName = $"TextFile{i}.txt";
				var nameToCreate = $"{path}\\{fileName}";
				if (File.Exists(nameToCreate))
				{
					File.Delete(nameToCreate);
				}
				var file = File.CreateText(nameToCreate);
				file.Close();
			}
		}

		private void CreateAndInflateFiles(string path, int numberOfFiles)
		{
			for (int i = 0; i < numberOfFiles; i++)
			{
				var fileName = $"TextFile{i}.txt";
				var nameToCreate = $"{path}\\{fileName}";
				if (File.Exists(nameToCreate))
				{
					File.Delete(nameToCreate);
				}
				var file = File.CreateText(nameToCreate);
				file.Write(FakeContentFile.GetContentFile());
				file.Flush();
				file.Close();
			}
		}

		[Test]
		public void DirectoryManagerShouldReturn0FilesReadWhenDirectoryIsEmpty()
		{
			//Arrange
			string dirPath = SetEnvironment();
			IDirectoryManager directoryManager = new DirectoryManager(10);

			//Act
			var numFiles = directoryManager.LoadFilesFromFolder(dirPath);

			//Assert
			Assert.AreEqual(0, numFiles);

			//Cleaning the environment
			DeleteDirectory(dirPath);
		}

		[Test]
		public void DirectoryManagerShouldReturn2FilesReadWhenDirectoryHas2EmptyFiles()
		{
			//Arrange
			var dirPath = SetEnvironment();
			CreateFiles(dirPath, 2);
			IDirectoryManager directoryManager = new DirectoryManager(10);

			//Act
			var numFiles = directoryManager.LoadFilesFromFolder(dirPath);

			//Assert
			Assert.AreEqual(2, numFiles);

			//Cleaning the environment
			DeleteDirectory(dirPath);
		}

		[Test]
		public void DirectoryManagerShouldReturnNoMatchesFoundWhenDirectoryHas2EmptyFiles()
		{
			//Arrange
			var dirPath = SetEnvironment();
			CreateFiles(dirPath, 2);
			IDirectoryManager directoryManager = new DirectoryManager(10);

			//Act
			var numFiles = directoryManager.LoadFilesFromFolder(dirPath);

			var stringResult = directoryManager.GetTopSearchWordMatches("hola");

			//Assert
			Assert.AreEqual(2, numFiles);
			Assert.AreEqual("no matches found\r\n", stringResult);

			//Cleaning the environment
			DeleteDirectory(dirPath);
		}

		[Test]
		public void DirectoryManagerShouldReturnSomeInformationWhendDirectoryHas2NonEmptyFiles()
		{
			//Arrange
			var dirPath = SetEnvironment();
			CreateAndInflateFiles(dirPath, 2);
			IDirectoryManager directoryManager = new DirectoryManager(10);

			//Act
			var numFiles = directoryManager.LoadFilesFromFolder(dirPath);

			var stringResult = directoryManager.GetTopSearchWordMatches("prueba");

			//Assert
			Assert.AreEqual(2, numFiles);
			Assert.AreNotEqual("no matches found\r\n", stringResult);

			//Cleaning the environment
			DeleteDirectory(dirPath);
		}
	}
}
