using NUnit.Framework;


namespace nunit_test
{
    
    public class Tests
    {
        private const string Expected = "Hello World!";
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string[] args = new string[] { @"D:\Repos\name-sorter\name-sorter\bin\Debug\netcoreapp3.1\unsorted-names-list.txt" };
            name_sorter.Program.Main(args);
            
            Assert.Pass();
        }
    }
}