using PollProject.Models;
using PollProject.Services;
namespace PollProjectTests
{
    public class InputCatcherTests
    {

        [TestCase("M,21,Human Resources,3")]
        public void InputOk(string screenInput)
        {
            var input = new StringReader(screenInput);
            Console.SetIn(input);

            List<PollResponse> results = InputResponsesCatcher.CatchInputResponses(1);

            var result = results.Find(r => r.Gender == "M" && r.Age == 21 && r.Studies == "Human Resources" && r.Academic_year == 3);

            Assert.IsTrue(result != null);
        }

        [TestCase("M,Human Resources,3", "Number of parameters must be 4: Gender, Age, Studies and Academic year")]
        [TestCase("M,21,Human Resources,3,aaa", "Number of parameters must be 4: Gender, Age, Studies and Academic year")]
        [TestCase("M,M,Human Resources,3", "Age parameter must be a number")]
        [TestCase("M,21,Human Resources,aaaa", "Academic year parameter must be a number")]
        public void InputFailWrongNumParameters(string screenInput, string exceptionMessage)
        {

            var input = new StringReader(screenInput);
            Console.SetIn(input);

            var ex = Assert.Catch<Exception>(() => InputResponsesCatcher.CatchInputResponses(1));

            Assert.That(ex.Message, Is.EqualTo(exceptionMessage));

        }
    }
}