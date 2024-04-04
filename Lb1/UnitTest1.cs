using Lb1;
using LabQA;
namespace Lb1
{
	public class Tests
	{
		[TestFixture]
		public class ProgramTests
		{
			private SP sP;
			private SortedSet<string> neededResult;
			private string filepath;

			[OneTimeSetUp]
			public void OneTimeSetUp()
			{
				filepath = "C:\\Users\\anton\\source\\repos\\LabQA\\LabQA\\test.txt";
				neededResult = new SortedSet<string> { "aaeabbb", "aahkiop", "arereeeeeeaaa", "eeeees", "hfksdaaaaaaa", "rionneuyu" };
			}

			[SetUp]
			public void Setup()
			{
				sP = new SP();
			}

			[Test]
			[Category("Group1")]
			public void TestIsRight()
			{
				Assert.IsTrue(sP.IsRight("hellooo"));
				Assert.IsFalse(sP.IsRight("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
			}

			[Test]
			[Category("Group1")]
			public void TestException()
			{
				// Test if an exception is thrown when passing a non-existing file path
				Assert.Throws<FileNotFoundException>(() => sP.Result("non-existing-file.txt"));
			}
			[TestCase("aaattt", ExpectedResult = false)]
			[TestCase("eeett", ExpectedResult = true)]
			[Category("Group2")]
			public bool TestIsRightWithParam(string word)
			{
				return sP.IsRight(word);
			}

			[Test]
			[Category("Group2")]
			public void TestHamcrestMatchers()
			{
				SortedSet<string> result = sP.Result(filepath);
				Assert.That(result, Is.EquivalentTo(neededResult));
				Assert.That(result, Has.Exactly(6).Items);
			}

		}
	}
}