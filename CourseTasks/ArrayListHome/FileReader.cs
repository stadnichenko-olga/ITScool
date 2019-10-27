using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    class FileReader
    {
        public static List<string> FileStringReder(string filePath)
        {
            try
            {
                List<string> result = new List<string>();

                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (true)
                    {
                        string temp = reader.ReadLine();
                        if (temp == null) break;
                        result.Add(temp);
                    }
                }

                return result;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found.");
                throw;
            }
        }
    }
}
