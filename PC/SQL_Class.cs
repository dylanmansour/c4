using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace TEF_Photo_Transfer
{
    public class SQL_Class
    {
       private string m_sDatabaseName = "";
        private string m_sServerName = "";
        private string m_sUserID = "";
        private string m_sPassword = "";
        public bool HasRecords = false;
        public long FieldCount = 0;
        private List<string> m_fields = new List<string>();

        public SQL_Class(string sServer, string sDBName, string sUserID, string sPwd)
        {
            m_sServerName = sServer;
            m_sDatabaseName = sDBName;
            m_sUserID = sUserID;
            m_sPassword = sPwd;
        }

        ~SQL_Class(){
        }

        public string GetFieldName(long index)
        {
            if (index < 0 || index > m_fields.Count)
                return "";

            long ct = 0;
            foreach (string f in m_fields)
            {
                if (index == ct)
                {
                    return f.ToString();
                }
                ct = ct + 1;
            }
            return "";
        }

        /// <summary>
        /// Requires a valid SQL query
        /// </summary>
        /// <param name="sQuery"></param>
        /// <returns></returns>
        public string Execute(string sQuery)
        {
            string sOut = ""; //all rows
            string sLine = "";//one row of result
            try //connecting
            {
                SqlConnection connection = new SqlConnection("user id=" + m_sUserID + ";" +
                                               "password=" + m_sPassword + ";server=serverurl;" +
                    //"Trusted_Connection=yes;" +
                                               "Server=" + m_sServerName + ";" +
                                               "database=" + m_sDatabaseName + "; " +
                                               "connection timeout=5");
                SqlCommand command = new SqlCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = sQuery;

                SqlDataReader myReader = null;
                m_fields.Clear();

                try//executing query
                {
                    myReader = command.ExecuteReader();
                    HasRecords = myReader.HasRows;
                    FieldCount = myReader.FieldCount;

                    for (int i = 0; i < myReader.FieldCount; ++i)
                    {
                        m_fields.Add(myReader.GetName(i));
                    }

                    while (myReader.Read())
                    {
                        sLine = "";
                        for (int i = 0; i < myReader.FieldCount; ++i)
                        {
                            sLine = sLine + myReader[i].ToString();

                            if (i < myReader.FieldCount - 1)
                                sLine = sLine + ",";     //delimiter                                         
                        }
                        sOut = sOut + sLine + "\r\n";//adds return
                    }
                }
                catch (Exception e)//failed query
                {
                    sOut = "Error: " + e.Message;
                }

                connection.Close();

            }
            catch (Exception e)//can't connect
            {
                sOut = "Error: " + e.ToString();
            }
            if (sOut.Length > 0)
              return sOut.Substring(0, sOut.Length - 1);//remove last line feed
            return "";
        }
    }

}
