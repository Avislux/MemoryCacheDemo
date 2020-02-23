using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemoryCacheDemo.Library
{
    public class Logger
    {
        public static void Write(string text) {
            string directory = AppDomain.CurrentDomain.BaseDirectory; //Project directory.
            string fileLocation = directory + "/Log.txt";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileLocation, true)) {
                file.WriteLine(text);
            }
            
        }
        public static void WriteV2(string text) {
            string directory = AppDomain.CurrentDomain.BaseDirectory; //Project directory.
            string fileLocation = directory + "/Log.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(fileLocation, true);
            file.WriteLine(text);
            file.Close();
        }
    }
}