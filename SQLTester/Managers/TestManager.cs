using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading;


namespace SQLTester.Managers
{
    class TestManager
    {


        /// <summary>
        /// Start the test based on existing parameters
        /// </summary>
        public void InitiateTest()
        {

            IOManager.WriteLine("");
            IOManager.WriteLineNP("#################  RUNNING TEST #################");


            //************************************************
            // DEBUG purposes. Uncomment to overwrite config
            //************************************************
            /*
              host = "vysoketatry\\sqlexpress";
              user = "sa";
              pass = "sa";
              db = "TankData";
              strNumOfTests = "1";
              numOfTests = 10;
              query = "select top 1  *  from vehicles";
             //-----------------------------------------
             */


            string status = "";

            //the connection string
            string connectionString = String.Format("Network Library=DBMSSOCN; Data Source={0},1433; Initial Catalog={1}; User ID={2}; Password={3};", ParamManager.host, ParamManager.db, ParamManager.user, ParamManager.pass);



            //loop for each test
            for (int i = 0; i < ParamManager.numOfTests; i++)
            {


                //print test number
                Console.Write("Test:" + i + " of " + ParamManager.numOfTests);


                using (SqlConnection conn = new SqlConnection(connectionString))
                {


                    
                    try
                    {
                        //connect
                        conn.Open();
                        LogManager.WriteLog("Successfully connected to " + ParamManager.host);
                        status = "PASS";

                    }
                    catch (Exception e)
                    {

                        //unable to connect. log as an error
                        LogManager.WriteLog("Error connecting to " + ParamManager.host + ". Message:" + e.Message, true);
                        status = "FAIL";
                    }


                    
                    if (ParamManager.readTests)
                    {


                        //user requested read tests
                        try
                        {

                            //red data
                            using (SqlCommand command = new SqlCommand(ParamManager.query, conn))
                            using (SqlDataReader reader = command.ExecuteReader())
                            {

                                //loop for each row
                                while (reader.Read())
                                {

                                    //get INTs and STRINGs and log. All else just say we received something
                                    //this only gets the first column of the dataset
                                    if (reader.GetDataTypeName(0) == "int")
                                    {
                                        LogManager.WriteLog("Data:" + reader.GetInt32(0).ToString());
                                    }
                                    else if (reader.GetDataTypeName(0) == "varchar")
                                    {
                                        LogManager.WriteLog("Data:" + reader.GetString(0));
                                    }
                                    else
                                    {
                                        LogManager.WriteLog("Received data");
                                    }

                                    status = "PASS";


                                }

                                reader.Close();
                            }

                            conn.Close();

                        }
                        catch (Exception e)
                        {
                            //unable to read data
                            LogManager.WriteLog("Error retrieving data from " + ParamManager.host + ". Message:" + e.Message, true);
                            status = "FAIL";
                        }

                    }
                }


                //say we are done and wait 
                IOManager.WriteLineNP("      (" + status + ")");
                Thread.Sleep(ParamManager.msBetweenTests);

            }

        }
    }
}
