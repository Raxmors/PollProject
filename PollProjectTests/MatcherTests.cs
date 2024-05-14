using PollProject.Services;
using PollProject.Models;

namespace PollProjectTests
{
    public class MatcherTests
    {
        List<PollResponse> List1 = new List<PollResponse>();
        List<PollResponse> List2 = new List<PollResponse>();
        List<PollResponse> List3 = new List<PollResponse>();

        [SetUp]
        public void SetUp()
        {
            List1 = new List<PollResponse>();
            List2 = new List<PollResponse>();
            List3 = new List<PollResponse>();

            PollResponse pollResponse1 = new PollResponse()
            {
                Name = "Name 1",
                Gender = "M",
                Age = 20,
                Studies = "Studies 1",
                Academic_year = 3
            };

            PollResponse pollResponse2 = new PollResponse()
            {
                Name = "Name 2",
                Gender = "F",
                Age = 22,
                Studies = "Studies 2",
                Academic_year = 2
            };

            PollResponse pollResponse3 = new PollResponse()
            {
                Name = "Name 3",
                Gender = "F",
                Age = 19,
                Studies = "Studies 3",
                Academic_year = 4
            };

            List1.Add(pollResponse1);
            List1.Add(pollResponse2);
            List1.Add(pollResponse3);
            List2.Add(pollResponse1);
            List2.Add(pollResponse2);
            List3.Add(pollResponse3);
        }

        [Test]
        public void MatchOK1match()
        {
            string result = Matcher.MatchResponses(List1, List3);
            Assert.IsTrue(result == "Case #1: Name 3\r\n");
        }

        [Test]
        public void MatchOK2matches()
        {
            string result = Matcher.MatchResponses(List1, List2);
            Assert.IsTrue(result == "Case #1: Name 1\r\nCase #2: Name 2\r\n");
        }

        [Test]
        public void MatchKONoMatches()
        {
            string result = Matcher.MatchResponses(List2, List3);
            Assert.IsTrue(result == "Case #1: NONE\r\n");
        }
    }
}