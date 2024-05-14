using PollProject.Models;
using PollProject.Services;


namespace PollProjectTests
{
    public class MapperTests
    {
        [Test]
        public void MapOk()
        {
            string[] testArray = { "Sophia Wright Torres,F,23,Radiologic Technology,1", "Chloe Gomez Green,F,22,Diagnostic Radiography,2" };

            List<PollResponse> pollResponses = Mapper.ToPollResponses(testArray);
            Assert.IsTrue(pollResponses.Count() == 2 && pollResponses[0].Name == testArray[0].Split(",")[0]);
        }

        [Test]
        public void MapKoNullArray()
        {
            List<PollResponse> pollResponses = Mapper.ToPollResponses(null);
            Assert.IsTrue(pollResponses.Count == 0);
        }
    }
}