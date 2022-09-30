using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Models
{
    internal class CohortModel
    {

        //Represents Cohort's ID
        public int CohortID { get; set; }   

        //Represents Cohort's name
        public string CohortName { get; set; }  = string.Empty;

        //Represents Cohort's start date
        public string StartDate { get; set; }   = string.Empty;

        //Represents Cohort's end date
        public string EndDate { get; set; }

        //Represents Cohort's completion status
        public string Status { get; set; } 

        //Represent a list of cohort member
        public List<UserModel> Members { get; set; } = new List<UserModel>();

        public string DisplayCohort { get { return CohortName + " -   Start Date: " + StartDate; } }

        public CohortModel()
        {
        }

        public CohortModel(int v, string cohortName, string status)
        {
            CohortName = cohortName;
            Status = status;
        }

        public CohortModel(int cohortID, string cohortName, string startDate, string status)
        {
            CohortID = cohortID;
            CohortName = cohortName;
            Status = status;
            StartDate = startDate.ToString("dd/MM/yyyy");
            Status = status;

            

        }

    }
}
