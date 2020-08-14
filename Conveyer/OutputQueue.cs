using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Conveyer
{
    class OutputQueue
    {
        static List<string> output = new List<string>();
        public OutputQueue(string item)
        {
            Regex reg = new Regex("^[a-zA-Z0-9]");
            if (reg.IsMatch(item)) //If input is a char to print
            {
                output.Add(item);
            }
            else //Ignore string
            {
                item = null;
            }
        }

    }
}
