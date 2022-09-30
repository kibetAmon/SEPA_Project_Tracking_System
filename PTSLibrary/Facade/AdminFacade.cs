using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Facade
{
    internal class AdminFacade : SuperFacade
    {
        private new DataAccess.AdminDAO dao;

        public AdminFacade() : base(new DataAccess.AdminDAO())
        {
            dao = (DataAccess.AdminDAO)base.dao;
        }
        //Authenticate
        public int Authenticate(string email, string password)
        {
            if (email == "" || email == "" || password == "")
            {
                throw new Exception("All fields must be filled");
            }
            return dao.Authenticate(email, password);
        }
        //Create project
        public void CreateProject(string projectName, string projectDescription, string level, int projectDuration, string github, string link)
        {
            if (projectName == null || projectDescription == "" || level == null)
            {
                throw new Exception("Please fill in all fields with * ");
            }
            dao.CreateProject(projectName, projectDescription, level, projectDuration, github, link);
        }
    }
}
