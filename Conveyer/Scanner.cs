using System;
using System.IO;
using System.Text.RegularExpressions;

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
            bool scanFinished = false;

            int h = 0;
            int l = 0;

            //Check if first belt go right of down and adjust scan 
            if(_map[1, 1] == '>') 
            {
                h = 1;
                l = 2;
            }
            else if(_map[0, 2] == 'ᵥ')
            {
                h = 0;
                l = 2;
            }

            for (; h < Controller.height;)
            {
                for (; l < length;)
                {
                    if (reg.IsMatch(_map[h, l].ToString())) //If current pos has a character to print, queue it
                    {
                        OutputQueue oQueue = new OutputQueue(_map[h, l]);//Add to output queue
                    }

                    if(_map[h, l] == '+')
                    {
                        OutputQueue oQueue = new OutputQueue(_map[h, l]);//Add to output queue
                    }
                    if (_map[h, l] == '-')
                    {
                        OutputQueue oQueue = new OutputQueue(_map[h, l]);//Add to output queue
                    }
                    if (_map[h, l] == '*')
                    {
                        OutputQueue oQueue = new OutputQueue(_map[h, l]);//Add to output queue
                    }
                    if (_map[h, l] == '/')
                    {
                        OutputQueue oQueue = new OutputQueue(_map[h, l]);//Add to output queue
                    }


                    //Console.WriteLine("h = " + h);
                    //Console.WriteLine("l = " + l);
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

                    if (_map[h, l] == '^') //Check For Direction --> go up
                    {
                        goUp = true;
                        moveSideways = false;
                    }
                    if (_map[h, l] == 'ᵥ') //Check For Direction --> go down
                    {
                        goUp = false;
                        moveSideways = false;
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

                    if ((_map[h - 1, l - 2] == '_' || _map[h + 1, l - 2] == '‾') && goRight == false && moveSideways == true) //Go left
                    {
                        l--;
                    }

                    if ((_map[h - 1, l + 2] == '_' || _map[h + 1, l + 2] == '‾') && goRight == true && moveSideways == true) //Go right
                    {
                        l++;
                    }

                    if (_map[h, l + 1] == '~' || _map[h, l - 1] == '~' || _map[h + 1, l] == '~' || _map[h - 1, l] == '~') //End of conveyor belt
                    {
                        //Console.WriteLine("Mission Complete!");
                        OutputQueue.Machine(); //Check for machines and then print result

                        scanFinished = true;
                        break;
                    }
                    #endregion
                }

                if (scanFinished == true)
                    break;
            }
        }
    }
}
