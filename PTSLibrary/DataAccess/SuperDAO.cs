using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PTSLibrary.Models;

namespace PTSLibrary.DataAccess
{
    internal class SuperDAO
    {
        protected UserModel GetUser(int ID)
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            SqlDataReader dr;
            UserModel user;

            sql = "SELECT * FROM customer WHERE CustomerID = " + ID;

            cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                dr.Read();
                user = new(dr["FirstName"].ToString(), dr["LastName"].ToString(), (int)dr["ID"]);
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting Customer", ex);
            }
            finally
            {
                con.Close();
            }
            return user;
        }
    }
}
