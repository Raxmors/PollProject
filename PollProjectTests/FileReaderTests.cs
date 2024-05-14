using PollProject.Services;
using PollProject;


namespace PollProjectTests
{
    public class FileReaderTests
    {
        [TestCase("students.txt")]
        public void ReadOk(string fileName)
        {
            string[] data = FileReader.GetResponses(fileName);
            Assert.IsTrue(data.Length > 1);
        }

        [TestCase("ssstudents.txt", "Data file doesn't exist")]
        public void ReadKo(string fileName, string exceptionMessage)
        {
            var ex = Assert.Catch<Exception>(() => FileReader.GetResponses(fileName));

            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));
        }
    }
}