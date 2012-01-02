using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLTester.Managers
{
    class HelpManager
    {

        private static string _Prompt = "ISTU> ";       //prompt text used throught the app        


        /// <summary>
        /// Prints the instructions
        /// </summary>
        public static void PrintInstructions()
        {

            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("test\t\t- to test a connection");            
            if (ParamManager.paramsSet) Console.WriteLine("retest \t\t- to run the previous test again");
            Console.WriteLine("?\t\t- show commands");
            Console.WriteLine("help\t\t- to print help");
            Console.WriteLine("license\t\t- for credits and licenses");
            Console.WriteLine("quit\t\t- to quit");
            Console.WriteLine("-------------------------------------------------------");
            Prompt();
        }


        /// <summary>
        //Print intial header
        /// </summary>
        public static void PrintInitialHeader()
        {


            Console.WriteLine(" _____            _ _       ");
            Console.WriteLine("|_   _|          (_) |      ");
            Console.WriteLine("  | |  __ _ _ __  _| |_ ___ ");
            Console.WriteLine("  | | / _. | ._ \\| | __/ _ \\");
            Console.WriteLine(" _| || (_| | | | | | ||  __/");
            Console.WriteLine("|_____\\__, |_| |_|_|\\__\\___|");
            Console.WriteLine("       __/ |                ");
            Console.WriteLine("      |___/  	       ");

        }




        /// <summary>
        //Print credits and licenses
        /// </summary>
        public static void PrintLicense()
        {
            Console.WriteLine("(C) IgniteMedia, LLC. SQL Test Utility");
            Console.WriteLine("");
            Console.WriteLine("This program is free software; you can redistribute it and/or");
            Console.WriteLine("modify it under the terms of the GNU General Public License");
            Console.WriteLine("as published by the Free Software Foundation; either version 2");
            Console.WriteLine("of the License, or (at your option) any later version.");
            Console.WriteLine("");
            Console.WriteLine("This program is distributed in the hope that it will be useful,");
            Console.WriteLine("but WITHOUT ANY WARRANTY; without even the implied warranty of");
            Console.WriteLine("MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the");
            Console.WriteLine("GNU General Public License for more details.");
            Console.WriteLine("");
            Console.WriteLine("IgniteMedia - http://www.ignitedev.com");
            
        }


        /// <summary>
        //Print help
        /// </summary>        
        public static void PrintHelp()
        {

            Console.WriteLine("");
            Console.WriteLine("######################################################");
            Console.WriteLine("                         HELP");
            Console.WriteLine("######################################################");
            Console.WriteLine("");

            Console.WriteLine("The application tests connectivity to a Microsoft SQL server. ");
            Console.WriteLine("It provides the ability to test connectivity only, or to perform a ");
            Console.WriteLine("read query in addition to a connectivity test. Tests can also be looped.  ");
            Console.WriteLine("The application logs data to normal.log and error.log located in ");
            Console.WriteLine("the same directory as from which the app is executed. If errors occur, ");
            Console.WriteLine("the app logs to error.log. Otherwise data is logged to normal.log. ");
            Console.WriteLine("");
            Console.WriteLine("To begin testing users press enter and provide several parameters such as host,");
            Console.WriteLine("DB name, credentials and the query. The query can be any SQL statement");
            Console.WriteLine("(so use the utility cautiously). If the statement is a select, the ");
            Console.WriteLine("utility will write the results of the first column only into the log. ");
            Console.WriteLine("All other columns are ignored sine this is meant to simply verify we can get data.");
            Console.WriteLine("");
            PrintInstructions();

        }


        /// <summary>
        //Write the prompt only
        /// </summary>        
        public static void Prompt()
        {
            Console.Write(_Prompt);
        }

    }
}
