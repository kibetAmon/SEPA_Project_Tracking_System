using PTSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.DataAccess
{
    internal class ClientDAO : SuperDAO
    {
        public int Authenticate(string email, string password)
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            SqlDataReader dr;
            sql = String.Format("SELECT ID FROM Users WHERE Email='{0}' AND Pwd='{1}'", email, password);

            cmd = new SqlCommand(sql, con);
            int id = 0;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    id = (int)dr["ID"];
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Accessing Database", ex);
            }
            finally
            {
                con.Close();
            }
            return id;
        }

        //List of cohort members
        public List<UserModel> GetListOfCohortMembers(int cohortID)
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            SqlDataReader dr;
            List<UserModel> members;
            members = new List<UserModel>();
            sql = String.Format("SELECT * FROM Users WHERE CohortID = '{0}'", cohortID);
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserModel c = new(dr["FirstName"].ToString(), dr["LastName"].ToString(), (int)dr["ID"]);
                    members.Add(c);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list of users", ex);
            }
            finally
            {
                con.Close();
            }
            return members;
        }

        //Create a task
        public void CreateTask(string task, int projectID)
        {
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            string sql;
            SqlConnection cn;
            SqlCommand cmd;
            Guid taskId = Guid.NewGuid();
            sql = "INSERT INTO Tasks (TaskName, ProjectID)";
            sql += String.Format("VALUES ('{0}','{1}')", task, projectID);
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Inserting", ex);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
