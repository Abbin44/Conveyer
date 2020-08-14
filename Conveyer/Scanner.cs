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

                    bool goUp = false;
                    bool goRight = true;
                    #region MazeCheck
                    if ((_map[h, l] == '_' || _map[h, l] == '|') && _map[h, l - 1] == '|' && _map[h, l + 1] == '|')//Go down
                    {
                        goUp = false;
                        h++;
                    }

                    if (_map[h + 1, l] == '‾' && _map[h, l - 1] == '|' && _map[h, l + 1] == '|' && goRight == true)//Go to the right 
                    {
                        Console.Write("Reeeek");
                        l++;
                        goUp = true;
                    }

                    if (_map[h + 1, l] == '‾' && (_map[h, l + 1] == '|' || _map[h, l - 1] == '|') && goUp == true) //Go up
                    {
                        h--;
                    }

                    if (_map[h, l + 1] == '|' && _map[h + 1, l] == '‾' && goRight == false)//Go to the left
                    {
                       l--;
                       goUp = true;
                    }
                    
                    if(_map[h, l + 1] == '~')
                    {
                         Console.WriteLine("~");
                    }
                    #endregion
                }
            }
            Console.ReadKey();
        }
    }
}
