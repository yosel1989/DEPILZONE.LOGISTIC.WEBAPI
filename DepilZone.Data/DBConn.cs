using System;
using System.Data.SqlClient;

namespace DepilZone.Data
{
    class DBConn
    {
        public static SqlConnection ConexionSQL()
        {
            try
            {
                  SqlConnection ConectString = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=BDDepilzone; User Id=sa; password=*#DEPIL#ZON3#");
                  //SqlConnection ConectString = new SqlConnection("Data Source=.; Initial Catalog=BDDepilzone_QA; User Id=sa; password=*#DEPIL#ZON3#");
                  //SqlConnection ConectString = new SqlConnection("Data Source=.; Initial Catalog=BDDepilzone; User Id=sa; password=*#DEPIL#ZON3#");
                  return ConectString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string ParametroCripto()
        {
            return "d/3%P.1@l?z!0&N(3";
        }
    }
}
