using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Conveyer
{
    class OutputQueue
    {
        static List<string> queue = new List<string>();
        public OutputQueue(string item)
        {
            Regex reg = new Regex("^[a-zA-Z0-9]");
            if (reg.IsMatch(item)) //If input is a char to print
            {
                queue.Add(item);
            }
            else //Ignore string
            {
                item = null;
            }
        }

        public static void PrintResult()
        {
            string output = "";
            for (int i = 0; i < queue.Count; i++)
            {
                output += queue[i];
            }
            Console.WriteLine("Items on belt adds up to: " + output);
        }

    }
}
