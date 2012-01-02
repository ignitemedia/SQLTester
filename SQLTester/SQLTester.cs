using System;
using System.Threading;
using System.IO;
using System.Text;
using SQLTester.Managers;



namespace SQLTester
{
    /// <summary>
    /// Tests for the ability to connect to a Sql Server
    /// </summary>
    class MainTester
    {


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            string command = "";

            //this is what runs the tests
            TestManager tm = new TestManager();
            
            //print the initial header
            HelpManager.PrintInitialHeader();

            //write out the instructions and show the prompt
            HelpManager.PrintInstructions();
            

            //process commands  - loop until the user exits
            while (true)
            {                               

                //read an input from the user
                command = Console.ReadLine();
                
                if (command == "quit" || command == "q" || command == "exit"){
                    //quit                    
                    IOManager.WriteLine("");                    
                    IOManager.WriteLine("Exiting...");                
                    return;    


                }else if (command == "help"){                    
                    //show the help
                    HelpManager.PrintHelp();                    

                
                }else if (command == "license"){
                    //show the license
                    HelpManager.PrintLicense();
                    HelpManager.Prompt();


                }else if (command == "?"){                                        
                    //print hte instructions again
                    HelpManager.PrintInstructions();

                }else if (command == "test"){                    
                    //configure and run the test
                    ParamManager.SetParameters();
                    if (ParamManager.initiateTest) { tm.InitiateTest(); }
                    HelpManager.Prompt();


                }else if (command == "retest" && ParamManager.paramsSet)
                {
                    //start the test based on previous params (retest)
                    tm.InitiateTest();
                    HelpManager.Prompt();
              

                }else
                {
                    //if no specific commands show an error
                    if (command != "") { IOManager.WriteLineNP(command + ": command not found"); }
                    HelpManager.Prompt();
                }
                
            }

        }
    
    }
}
