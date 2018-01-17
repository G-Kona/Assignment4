using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Asgmt4_GeriKona.Models;

namespace Asgmt4_GeriKona.Models
{
    public class DBVendors
    {
        //Fields
        private static string host = "calvin.humber.ca";
        private static string port = "1521";
        private static string sid = "grok";
        private static string username = OracleLogin.user;
        private static string password = OracleLogin.pass;
        private static string connString = OracleConnString(host, port, sid, username, password);

        protected OracleConnection conn = new OracleConnection(connString);
        protected OracleCommand cmd;
        protected OracleDataReader rdr;

        //Method from Chris Hulbert - DB Connection String
        private static string OracleConnString(string host, string port, string servicename, string user, string pass)
        {
            return String.Format(
              "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})" +
              "(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};",
              host,
              port,
              servicename,
              user,
              pass);
        }

    }
}