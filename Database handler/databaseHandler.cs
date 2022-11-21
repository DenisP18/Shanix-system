using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Demo.Database_handler
{
    public class databaseHandler
    {

        private Database db;
        private DbCommand command;
        public string database = "MoMo";
        DataTable dt = new DataTable();

        public databaseHandler()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();

            db = factory.Create(database);


        }

        public DataTable retrieveData(string procedure, object[] parameters)
        {

            try
            {

                command = db.GetStoredProcCommand( procedure, parameters);

                command.CommandTimeout = 1000;
                dt = db.ExecuteDataSet(command).Tables[0];
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public string ExecuteDataSet(string procedure, object[] parameters)
        {

            try
            {
                if (parameters.Length.Equals(0))
                {
                    command = db.GetStoredProcCommand(procedure);
                }
                else
                {
                    command = db.GetStoredProcCommand(procedure, parameters);
                }
                command.CommandTimeout = 1000;
                string result = Convert.ToString(db.ExecuteNonQuery(command));
                return result;


            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}