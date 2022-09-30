using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Models
{
    public class ProjectModel
    {
        //Project ID
        public int ProjectID { get; set; } 

        //Project Code
        public string ProjectCode { get; set; } 
        
        //Project Name
        public string ProjectName { get; set; }  

        //Project Description
        public string ProjectDescription { get; set; }

        //Project Tasks
        public string ProjectTasks { get; set; }

        //Project level
        public string Level { get; set; }

        //Project Duration
        public int ProjectDuration { get; set; }    

        //Project Github repo
        public string Github { get; set; } = string.Empty;

        //Project Video link
        public string Link { get; set; } = string.Empty ;

        //Project code and name
        public string DisplayProject { get { return ProjectCode + " - " + ProjectName; } }

        public ProjectModel()
        {

        }

        //Constructor
        public ProjectModel(int projectID, string projectCode, string projectName, string projectDescription,
           string projectTasks, string level, int projectDuration, string github, string link)
        {
            ProjectID = projectID;
            ProjectCode = projectCode;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            ProjectTasks = projectTasks;
            Level = level;
            ProjectDuration = projectDuration;
            Github = github;
            Link = link;
        }

        public ProjectModel(string projectName, string projectDescription, string projectTasks, string level, int projectDuration, string github, string link)
        {
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            ProjectTasks = projectTasks;
            Level = level;
            ProjectDuration = projectDuration;
            Github = github;
            Link = link;
        }

        public ProjectModel(string projectCode, string projectName)
        {
            ProjectCode = projectCode;
            ProjectName = projectName;
        }



    }
}
