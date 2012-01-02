using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace SQLTester.Managers
{
    class LogManager
    {

        /// <summary>
        /// Write data into a log file. 
        /// </summary>
        public static void WriteLog(string sErrMsg, Boolean isError = false)
        {

            string errorLogFileName = "error.log";
            string normalLogFileName = "normal.log";
            string fileName = "";

            if (isError)
            {
                fileName = errorLogFileName;
            }
            else
            {
                fileName = normalLogFileName;
            }

            StreamWriter sw = new StreamWriter(fileName, true);
            sw.WriteLine(GetDateTimeHeader() + sErrMsg);
            sw.Flush();
            sw.Close();
        }


        /// <summary>
        /// Get the formatted header
        /// </summary>
        private static string GetDateTimeHeader()
        {

            string format = "dd/MM/yyyy HH:mm:ss.ff";
            string str = DateTime.Now.ToString(format, CultureInfo.InvariantCulture);
            DateTime date = DateTime.ParseExact(str, format, CultureInfo.InvariantCulture);
            string str1 = date.ToString(format, CultureInfo.InvariantCulture);
            return str1 + " - ";

            // dd/mm/yyyy hh:mm:ss AM/PM ==> Log Message
            //return DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + DateTime.Now.to " - ";


        }

    }
}
