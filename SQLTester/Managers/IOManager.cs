using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLTester.Managers
{
    class IOManager
    {


        /// <summary>
        //Write without the prompt. Just a wrapper on top of Console to keep IO in on class
        /// </summary>        
        public static void WriteLineNP(string format)
        {            
            Console.WriteLine(format);
        }
        
        /// <summary>
        //Write the prompt and also teh parameter string
        /// </summary>        
        public static void WriteLine(string format)
        {
            HelpManager.Prompt();
            Console.WriteLine(format);
        }


        /// <summary>
        //Write the prompt and also teh parameter string with arguments
        /// </summary>        
       public static void WriteLine(string format, params string[] args)
        {
            HelpManager.Prompt();
            Console.WriteLine(format, args);
        }


       /// <summary>
       //Return user's input
       /// </summary>        
       public static string CaptureInput(string message)
       {
           HelpManager.Prompt();
           Console.Write(message);
           return Console.ReadLine().Trim();
       }


    }
}
