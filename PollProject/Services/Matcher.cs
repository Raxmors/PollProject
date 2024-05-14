using PollProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PollProject.Services
{
    public static class Matcher
    {
        /// <summary>
        /// Function that receive a list of the inputs added and a list of the data to check if matches and get the names to generate the outputs in every case.
        ///  1. Using linQ to check in every input case if matches with the data. The result is just the Name and it's sorted Alphabeticaly.
        ///  2. In case there are no matches the output is "NONE"
        ///  3. Return an String with the response output.
        /// </summary>
        /// <param name="pollResponses"></param>
        /// <param name="inputResponses"></param>
        public static string MatchResponses(List<PollResponse> pollResponses, List<PollResponse> inputResponses)
        {
            int caseIteration = 0;
            var output = new StringBuilder();
            foreach (PollResponse inputResponse in inputResponses)
            {
                caseIteration++;
                String[] matchNames = pollResponses.Where(pr => pr.Gender == inputResponse.Gender
                                                             && pr.Age == inputResponse.Age
                                                             && pr.Studies == inputResponse.Studies
                                                             && pr.Academic_year == inputResponse.Academic_year)
                                            .OrderBy(pr => pr.Name)
                                            .Select(pr => pr.Name).ToArray();

                string outputline = matchNames.Count() > 0 ? String.Join(",", matchNames) : "NONE";

                output.AppendLine("Case #" + caseIteration + ": " + outputline);
            }

            return output.ToString();
        }
    }
}
