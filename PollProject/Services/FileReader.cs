using PollProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PollProject.Services
{
    public static class FileReader
    {

        /// <summary>
        /// Function that read the data file and returns a list with all the data
        /// </summary>
        /// <returns>Array with the file data</returns>
        public static string[] GetResponses(string filename)
        {
            return File.Exists(filename) ? File.ReadAllLines(filename) : throw new Exception("Data file doesn't exist");
        }
    }
}
