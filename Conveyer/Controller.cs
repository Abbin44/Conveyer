using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Conveyer
{
    class Controller
    {
        static string filePath;
        static public int height;

        static void Main(string[] args)
        {
            // Check for correct file format and length            
            if (!(args.Length == 1 && args[0].EndsWith(".coy")))
            {
                Console.WriteLine("Code not a valid file");
                Console.ReadKey();
                return;
            }
            filePath = args[0];
            height = File.ReadLines(filePath).Count();

            FileHandler fh = new FileHandler(filePath);
        }

        static public void CreateArray(int length)
        {
            //Lenght is the horizontal lenght which varies depending on the code inputed
            var map = new char[height, length];

            StreamReader sr = new StreamReader(filePath);

            //line is the temp string that carries each read line
            string line;

            //lineCount is used to index the vertical lines
            var lineCount = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (lineCount <= height)
                {
                    for (int i = 0; i < length; i++)
                    {
                        //Add all chars of line to the correct positions in the map array
                        map[lineCount, i] = line[i];
                    }
                    if (lineCount < height)
                        lineCount++;
                }
            }
            //Close streamreader to avoid memory leak
            sr.Close();

            #region PrintArray
            /*
            //Print array
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(string.Format("{0} ", map[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            */
            #endregion

            Scanner sc = new Scanner(length, map, filePath);
            Console.ReadKey();
        }
    }
}
