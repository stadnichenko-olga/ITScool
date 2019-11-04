using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class FileReader
    {
        public static List<string> ReadStringsFromFile(string filePath)
        {
            List<string> result = new List<string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (true)
                    {
                        string temp = reader.ReadLine();
                        if (temp == null)
                        {
                            break;
                        }
                        result.Add(temp);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }
    }
}
