using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Conveyer
{
    class OutputQueue
    {
        static List<char> queue = new List<char>(); //Queue is ALL the ingoing chars, including +-*/ A-Z 0-9
        static List<string> result = new List<string>();//Result is the final computation where +-*/ has been calculated and removed from the list.

        static Regex dReg = new Regex("[+/*\\-]"); //Reg for operators
        static Regex cReg = new Regex("^[a-zA-Z0-9]"); //Reg for letters and numbers

        public OutputQueue(char item)
        {
            if (cReg.IsMatch(item.ToString()) || dReg.IsMatch(item.ToString())) //If input is a char to print
            {
                queue.Add(item);
            }
        }

        public static void Machine()
        {
            float number = 0.0f;
            int startIndex = 0; //start index for current operator to offset the starting index after every operator
            int lastOpIndex = 0;//Index of the last operator so that it can be used as a starting index to output all chars after the last operator.

            bool noMachines = true;

            int i = 0;
            for (; i < queue.Count; i++)//Check if i contains any operators +-*/
            {
                if (dReg.IsMatch(queue[i].ToString()))//If i is an operator, + - * /
                {
                    noMachines = false; //If there is atleast one machine on the belt
                    lastOpIndex = i;
                    for (int j = startIndex; j < i; j++) //Iterate through all previous numbers
                    {
                        if (char.IsLetter(queue[j]))
                        {
                            result.Add(queue[j].ToString());
                            continue;
                        }

                        if (number == 0)
                        {
                            number = (float)char.GetNumericValue(queue[j]);
                            continue;
                        }

                        if (queue[i] == '+')
                        {
                            if (cReg.IsMatch(queue[j].ToString()))
                            {
                                number += (float)char.GetNumericValue(queue[j]);
                                continue;
                            }
                        }

                        if (queue[i] == '-')
                        {
                            if (cReg.IsMatch(queue[j].ToString()))
                            {
                                number -= (float)char.GetNumericValue(queue[j]);
                                continue;
                            }
                        }

                        if (queue[i] == '*')
                        {
                            if (cReg.IsMatch(queue[j].ToString()))
                            {
                                number *= (float)char.GetNumericValue(queue[j]);
                                continue;
                            }
                        }

                        if (queue[i] == '/')
                        {
                            if (cReg.IsMatch(queue[j].ToString()))
                            {
                                number /= (float)char.GetNumericValue(queue[j]);
                                continue;
                            }
                        }
                    }
                    result.Add(number.ToString());
                    startIndex = i + 1;
                    number = 0;
                }
            }

            if(noMachines == true)
            {
                for (int s = 0; s < queue.Count; s++)
                {
                    if (cReg.IsMatch(queue[s].ToString()))
                    {
                        result.Add(queue[s].ToString());
                    }
                }
            }
            else
            {
                //Add letters if there are any after the last operator
                for (int t = lastOpIndex; t < queue.Count; t++)
                {
                    if (char.IsLetter(queue[t])) //Add letters to array in correct order
                        result.Add(queue[t].ToString());
                }
            }
            PrintResult();
        }

        public static void PrintResult()
        {
            string output = "";
            for (int i = 0; i < result.Count; i++)
            {
                output += result[i];
            }
            Console.WriteLine("Items on belt adds up to: " + output);
        }

    }
}
