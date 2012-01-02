using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLTester.Managers
{
    public class ParamManager
    {

        /// <summary>
        /// <param name='host'>SQL Server Host</param>
        /// </summary>
        public static string host { get; set; }

        /// <summary>
        /// <param name='host'>Username to connect as</param>
        /// </summary>
        public static string user { get; set; }

        /// <summary>
        /// <param name='host'>Password to connect as</param>
        /// </summary>
        public static string pass { get; set; }

        /// <summary>
        /// <param name='host'>Database name</param>
        /// </summary>
        public static string db { get; set; }

        /// <summary>
        /// <param name='host'>Number of tests to execute</param>
        /// </summary>
        public static int numOfTests { get; set; }

        /// <summary>
        /// <param name='host'>The Query to execute</param>
        /// </summary>
        public static string query { get; set; }

        /// <summary>
        /// <param name='host'>How long to wait between tests</param>
        /// </summary>
        public static int msBetweenTests { get; set; }

        /// <summary>
        /// <param name='host'>Should we perform the read tests?</param>
        /// </summary>
        public static Boolean readTests { get; set; }

        /// <summary>
        /// <param name='host'>Are the parameters set?</param>
        /// </summary>
        public static Boolean paramsSet { get; set; }

        /// <summary>
        /// <param name='host'>Should we initiate the test?</param>
        /// </summary>
        public static Boolean initiateTest { get; set; }


        /// <summary>
        //Clear the connection and other parameters
        /// </summary>        
        public static void ClearParams()
        {

            host = "";
            user = "";
            pass = "";
            db = "";
            numOfTests = 0;
            query = "";
            msBetweenTests = 0;
            paramsSet = false;
            initiateTest = false;

        }



        /// <summary>
        //Set the connection and other parameters
        /// </summary>        
        public static void SetParameters()
        {

            //temp strings
            string strNumOfTests = "";
            string strMsBetweenTests = "";
            
            //print some help
            IOManager.WriteLineNP("Enter the required information when prompted");
            IOManager.WriteLineNP("Leaving a field blank will take you back to the home state");


            //get host
            ParamManager.host = IOManager.CaptureInput("Host:");
            if (ParamManager.host == "") { return; }

            //get DB name
            ParamManager.db = IOManager.CaptureInput("Database:");
            if (ParamManager.db == "") { return; }

            //get username
            ParamManager.user = IOManager.CaptureInput("Username:");
            if (ParamManager.user == "") { return; }

            //get password
            ParamManager.pass = IOManager.CaptureInput("Password:");
            if (ParamManager.pass == "") { return; }


            //how many test do we run?
            ParamManager.numOfTests = 0;
            while (ParamManager.numOfTests < 1)
            {
                strNumOfTests = IOManager.CaptureInput("Number of tests (1-n):");

                try
                {
                    ParamManager.numOfTests = int.Parse(strNumOfTests);
                }
                catch
                {
                    IOManager.WriteLine("Enter a number > 0");
                }
            }


            //what is the wait time between tests
            if (numOfTests > 1)
            {
                ParamManager.msBetweenTests = 0;
                while (ParamManager.msBetweenTests < 1)
                {
                    strMsBetweenTests = IOManager.CaptureInput("Number of milliseconds between tests:");

                    try
                    {
                        ParamManager.msBetweenTests = int.Parse(strMsBetweenTests);
                    }
                    catch
                    {
                        IOManager.WriteLine("Enter a number > 0");
                    }
                }
            }
            
            

            //should we perform resd tests?
            Boolean goodYesNoPrompt = false;
            while (goodYesNoPrompt == false)
            {

                string yesNo = IOManager.CaptureInput("Test reads? (y/n):");


                if (yesNo == "y")
                {
                    ParamManager.readTests = true;

                    ParamManager.query = IOManager.CaptureInput("Query:");
                    if (ParamManager.query == "") { return; }
                    goodYesNoPrompt = true;

                }
                if (yesNo == "n")
                {
                    ParamManager.readTests = false;
                    goodYesNoPrompt = true;
                }


            }


            //run the tests now?
            goodYesNoPrompt = false;
            while (goodYesNoPrompt == false)
            {

                string yesNo = IOManager.CaptureInput("Start the test? (y/n):");


                if (yesNo == "y" || yesNo == "n")
                {
                    goodYesNoPrompt = true;
                    ParamManager.paramsSet = true;

                    if (yesNo == "y")
                    {
                        ParamManager.initiateTest = true;
                    }

                    
                }
            }

        }

    }





}
