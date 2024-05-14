using PollProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PollProject.Services
{
    public static class InputResponsesCatcher
    {

        /// <summary>
        /// Function that recieve the number of inputs needed to check and generate a list with this data.
        /// 1. Reading inputs the times that indicates the number parameter received.
        /// 2. Check the number of parameters in every input. If it's different to four, throw a message
        /// 3. Check if second (Age) and fourth (Academic year) parameters are numbers, if not, throw a message
        /// </summary>
        /// <param name="number"></param>
        /// <returns>List of input data added</returns>
        public static List<PollResponse> CatchInputResponses(int number)
        {

            List<PollResponse> inputResponses = new List<PollResponse>();
            for (int i = 0; i < number; i++)
            {
                PollResponse responseInput = new PollResponse();
                string[] responseInputs = Console.ReadLine().Split(",");
                if (responseInputs.Count() != 4) { throw new Exception("Number of parameters must be 4: Gender, Age, Studies and Academic year"); }
                responseInput.Gender = responseInputs[0];
                responseInput.Age = int.TryParse(responseInputs[1], out int age) ? age : throw new Exception("Age parameter must be a number");
                responseInput.Studies = responseInputs[2];
                responseInput.Academic_year = int.TryParse(responseInputs[3], out int academic_year) ? academic_year : throw new Exception("Academic year parameter must be a number");
                inputResponses.Add(responseInput);
            }

            return inputResponses;

        }
    }
}
