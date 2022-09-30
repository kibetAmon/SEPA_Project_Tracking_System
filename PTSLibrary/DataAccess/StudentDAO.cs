using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PTSLibrary.Models;
using PTSLibrary.DataAccess;

namespace PTSLibrary.DataAccess
{
    internal class StudentDAO : SuperDAO
    {
        //Authenticate the student
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

        //Get cohort
        public CohortModel GetCohort(int ID)
        {
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            string sql = String.Format("SELECT CohortID FROM Users WHERE ID='{0}'", ID);
            SqlCommand cmd = new(sql, con);
            CohortModel cohort;
            cohort = new CohortModel();
            SqlDataReader dr;
            try
            {
                con.Open();
                dr = cmd.ExecuteReader(CommandBehavior.SingleRow);
                if (dr.Read())
                {
                    DateTime startDate = DateTime.Parse(dr["StartDate"].ToString());
                    cohort = new((int)dr["CohortID"], dr["CohortName"].ToString(), startDate, dr["Status"].ToString());
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error fetching cohort", ex);
            }
            finally
            {
                con.Close();
            }
            return cohort;

        }

        //List of the assigned projects that are complete
        public List<ProjectModel> GetListOfAssignedProjects(int cohortID)
        {
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlDataReader dr;
            List<ProjectModel> completeProjects;
            completeProjects = new List<ProjectModel>();
            string sql = String.Format("SELECT * FROM Projects INNER JOIN AssignedProject on " +
                "Projects.ProjectID=AssignedProjects.ProjectID WHERE " +
                "AssignedProjects.CohortID='{0}' AND Status='complete'", cohortID);
            SqlCommand cmd = new(sql, con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ProjectModel p = new(dr["ProjectCode"].ToString(), dr["ProjectName"].ToString());
                    completeProjects.Add(p);
                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list of complete projects", ex);
            }
            finally
            {
                con.Close();
            }
            return completeProjects;
        }

        //Get current project
        public ProjectModel GetCurrentProjects(int cohortID)
        {
            SqlConnection con = new(Properties.Settings.Default.PTSConnectionstring);
            SqlDataReader dr;
            ProjectModel currentProjects;
            currentProjects = new ProjectModel();
            string sql = String.Format("SELECT * FROM Projects INNER JOIN AssignedProject on " +
                "Projects.ProjectID=AssignedProjects.ProjectID WHERE " +
                "AssignedProjects.CohortID='{0}' AND Status='complete'", cohortID);
            SqlCommand cmd = new(sql, con);
            try
            {
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    currentProjects = new(dr["ProjectCode"].ToString(), dr["ProjectName"].ToString());

                }
                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Getting list of complete projects", ex);
            }
            finally
            {
                con.Close();
            }
            return currentProjects;
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
    }
}
