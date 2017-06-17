using NUnit.Framework;
using System;
using Stregsystem;

namespace Tests
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void Test_ReadingUsersFile_Length_ShouldPass()
		{
			ReadingFiles readingFiles = new ReadingFiles();

			Assert.AreEqual(60, readingFiles.ReadingUsersFile().Count);
		}

		[Test()]
		public void Test_ReadingUsersFile_Length_ShouldFail()
		{
			ReadingFiles readingFiles = new ReadingFiles();

            Assert.AreNotEqual(59, readingFiles.ReadingUsersFile().Count);
		}

		[Test()]
		public void Test_ReadingProducsFile_Length_ShouldPass()
		{
			ReadingFiles readingFiles = new ReadingFiles();

			Assert.AreEqual(134, readingFiles.ReadProductsFile().Count);
		}

		[Test()]
		public void Test_ReadingProducsFile_Length_ShouldFail()
		{
			ReadingFiles readingFiles = new ReadingFiles();

            Assert.AreNotEqual
                  (133, readingFiles.ReadProductsFile().Count);
		}
}