using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Spares_Web.Models
{
    public class DBCommon
    {
        private static string conn = @"Data Source=.;Initial Catalog=SparesDSP;Integrated Security=True";

        public static IDbConnection Conexion()
        {
            return new SqlConnection(conn);
        }
    }
}