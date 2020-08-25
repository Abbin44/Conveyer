using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Conveyer
{
    class Scanner
    {
        public Scanner(int length, char[,] _map, string filePath)
        {
            Scan(length,  _map);
        }

        void Scan(int length, char[,] _map)
        {           
            Regex reg = new Regex("^[a-zA-Z0-9]");

            bool goUp = false;
            bool goRight = true;
            bool moveSideways = true;

            for (int h = 1; h < Controller.height;)
            {
                for (int l = 2; l < length;)
                {
                    if (reg.IsMatch(_map[h, l].ToString())) //If current pos has a character to print, queue it
                    {
                        OutputQueue oQueue = new OutputQueue(_map[h, l].ToString());//Add to output queue
                    }
                    Console.WriteLine("h = " + h);
                    Console.WriteLine("l = " + l);
                    #region MazeCheck


                    if (_map[h, l - 1] == '>') //Check For Direction --> go right
                    {
                        moveSideways = true;
                        goRight = true;
                    }

                    if (_map[h, l + 1] == '<') //Check For Direction --> go left
                    {
                        moveSideways = true;
                        goRight = false;
                    }

                    if (_map[h - 1, l] == '^') //Check For Direction --> go up
                    {
                        goUp = true;
                        moveSideways = false;
                        Console.WriteLine("GooooUP");
                    }
                    if (_map[h, l] == 'ᵥ') //Check For Direction --> go down
                    {
                        goUp = false;
                        moveSideways = false;
                        Console.WriteLine("GooooDOWN");
                    }

                    if (_map[h, l - 1] == '|' && _map[h, l + 1] == '|' && goUp == false && moveSideways == false) //Go down
                    {
                        if(_map[h + 1, l] != '‾')
                            h++;
                    }

                    if (_map[h, l - 1] == '|' && _map[h, l + 1] == '|' && goUp == true && moveSideways == false) //Go up
                    {
                        h--;
                    }

                    if (_map[h + 1, l - 2] == '‾' && goRight == false && moveSideways == true) //Go left
                    {
                        l--;
                    }

                    if (_map[h + 1, l + 2] == '‾' && goRight == true && moveSideways == true) //Go right
                    {
                        l++;
                    }

                    if (_map[h, l + 1] == '~') //End of conveyor belt
                    {
                        Console.WriteLine("Mission Complete!");
                        break;
                    }
                    #endregion
                }
            }
            Console.ReadKey();
        }
    }
}
