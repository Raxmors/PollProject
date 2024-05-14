using PollProject.Models;
using System;
using System.Collections.Generic;

namespace PollProject.Services
{
    public static class Mapper
    {
        /// <summary>
        /// Function that receives an Array with the data and generate a list of Poll data
        /// 1. For every value in the array, the values are separated and added in every Poll data attribute
        /// </summary>
        /// <param name="fileResponses"></param>
        /// <returns>List of all the Poll data</returns>
        public static List<PollResponse> ToPollResponses(string[] fileResponses)
        {
            List<PollResponse> pollResponses = new List<PollResponse>();
            if (fileResponses != null)
            {
                foreach (string r in fileResponses)
                {
                    string[] questions = r.Split(",");
                    PollResponse pollResponse = new PollResponse()
                    {
                        Name = questions[0],
                        Gender = questions[1],
                        Age = Convert.ToInt32(questions[2]),
                        Studies = questions[3],
                        Academic_year = Convert.ToInt32(questions[4])
                    };
                    
                    pollResponses.Add(pollResponse);
                }
            }
              
            return pollResponses;
        }
    }
}
