using TestAutomationFramework.Config;
using System;
using System.IO;

namespace TestAutomationFramework.Helpers
{
    public class LogHelpers
    {
        //Global Declaration
        private static string _logFileName = string.Format("{0:yyyymmddhhmmss}", DateTime.Now);
        private static StreamWriter _streamw = null;

        //Create a file which can store the log information
        public static void CreateLogFile()
        {
            
        }



        //Create a method which can write the text in the log file
        public static void Write(string logMessage)
        {

        }


    }
}
