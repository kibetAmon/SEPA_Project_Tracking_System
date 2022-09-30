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
    internal class AdminDAO : SuperDAO
    {
        //Authenticate Admin
        public int Authenticate(string email, string password)
        {
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            string sql = String.Format("SELECT AdminID from Admin WHERE email='0' and pwd='1'", email, password);
            SqlCommand cmd = new(sql, con);
            int id = 0;

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    id = (int)dr["AdminID"];
                }
                else
                {
                    Console.WriteLine("Incorrect email or password!");
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error accessing database", ex);
            }
            finally { con.Close(); }

            return id;
        }

        //Add project to database
        public void CreateProject(string projectName, string projectDescription,
            string level, int projectDuration, string github, string link)
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            sql = "INSERT INTO Projects (ProjectName, ProjectDescription, Duration, Level, GithubRepo, VideoLink, ProjectTasks)";
            sql += String.Format("VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',' ')", projectName, projectDescription, projectDuration, level, github, link);
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error adding new project", ex);
            }
            finally
            {
                con.Close();
            }
        }

        //Delete a project 
        public void DeleteProject(int id)
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            sql = String.Format("DELETE FROM projects WHERE ProjectID='{0}'", id);
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error deleting project", ex);
            }
            finally
            {
                con.Close();
            }
        }

        //Edit existing project 
        public void UpdateProject(string projectName, string description,
            string level, int duration, string github, string link, int projectID)
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            sql = String.Format("UPDATE Projects SET ProjectName = '{0}', ProjectDescription ='{1}', Duration='{2}', Level='{3}', " +
                "GithubRepo='{4}', VideoLink='{5}' WHERE ProjectID = '{6}'", projectName, description, duration, level, github, link, projectID);
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error updating project", ex);
            }
            finally
            {
                con.Close();
            }
        }

        //Create Cohort
        public void CreateCohort(DateTime startDate)
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            sql = "INSERT INTO Cohort (StartDate)";
            sql += String.Format("VALUES ('{0}')", startDate);
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error creating new cohort", ex);
            }
            finally
            {
                con.Close();
            }
        }

        //List the general users
        public List<UserModel> GetListOfUsers()
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            SqlDataReader dr;
            List<UserModel> users;
            users = new List<UserModel>();
            sql = "SELECT * FROM Users WHERE UserRole != teamleader";
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserModel c = new(dr["FirstName"].ToString(), dr["LastName"].ToString(), (int)dr["ID"]);
                    users.Add(c);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list", ex);
            }
            finally
            {
                con.Close();
            }
            return users;
        }

        //List the teamleaders
        public List<UserModel> GetListOfTeamLeaders()
        {
            string sql;
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlCommand cmd;
            SqlDataReader dr;
            List<UserModel> users;
            users = new List<UserModel>();
            sql = "SELECT * FROM Users WHERE UserRole = teamleader";
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    UserModel c = new(dr["FirstName"].ToString(), dr["LastName"].ToString(), (int)dr["ID"]);
                    users.Add(c);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list", ex);
            }
            finally
            {
                con.Close();
            }
            return users;
        }


    }
}
