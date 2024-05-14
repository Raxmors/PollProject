using System;
using System.Collections.Generic;
using PollProject.Models;
using PollProject.Services;

namespace PollProject
{
    public class Program
    {   /// <summary>
        /// Main function in charge to manage the rest of the code.
        /// 1. Check if the first input is a number that indicate the number of rows of data will be introduced.
        /// 2. Store the data from the number of inputs introduced.
        /// 3. Read the .txt file and load the data in a list.
        /// 4. Check the inputs introduced in the previous charged list.
        /// </summary>
        static void Main()
        {
            try
            {
                string inputNumber = Console.ReadLine();
                if (int.TryParse(inputNumber, out int number) == false) { throw new Exception("Please, indicate the number of lines to add"); };
                List<PollResponse> inputResponses = InputResponsesCatcher.CatchInputResponses(number);
                string[] fileResponses = FileReader.GetResponses("students.txt");
                List<PollResponse> pollResponses = Mapper.ToPollResponses(fileResponses);
                Console.WriteLine(Matcher.MatchResponses(pollResponses, inputResponses));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
     
    }
}
