namespace Lab1
{
	[TestFixture]
	public class ProgramTests
	{
		private SP program;

		[SetUp]
		public void Setup()
		{
			program = new SP();
		}

		[Test]
		public void TestIsRight()
		{
			Assert.IsTrue(program.IsRight("hello"));
			Assert.IsFalse(program.IsRight("world"));
		}

		[Test]
		public void TestReadTextFile()
		{
			// Test reading a sample text file
			// For simplicity, you may want to have a test.txt file with known content for testing
			Assert.DoesNotThrow(() => program.ReadTextFile("test.txt"));
		}

		[Test]
		public void TestException()
		{
			// Test if an exception is thrown when passing a non-existing file path
			Assert.Throws<FileNotFoundException>(() => program.ReadTextFile("non-existing-file.txt"));
		}

		[Test]
		public void TestSetResultContainsWords()
		{
			// Test if the setResult contains expected words after reading a sample text file
			program.ReadTextFile("test.txt");
			Assert.Contains("hello", program.SetResult);
			Assert.Contains("world", program.SetResult);
		}

		[Test]
		public void TestSetResultDoesNotContainWords()
		{
			// Test if the setResult does not contain unexpected words after reading a sample text file
			program.ReadTextFile("test.txt");
			Assert.IsFalse(program.SetResult.Contains("unexpected"));
		}

		[TestCase("hello", ExpectedResult = true)]
		[TestCase("world", ExpectedResult = false)]
		public bool TestIsRightWithParam(string word)
		{
			return program.IsRight(word);
		}

		[Test]
		public void TestHamcrestMatchers()
		{
			// Test Hamcrest Matchers
			Assert.That(program.SetResult, Is.All.Not.Null.Or.Empty);
			Assert.That(program.SetResult, Has.Exactly(2).Items);
		}
	}
}
