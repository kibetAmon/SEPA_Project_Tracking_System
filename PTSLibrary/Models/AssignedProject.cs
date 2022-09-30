using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Models
{
    public class AssignedProject
    {
        public int AssignedProjectID { get; set; }
        public string StartDate { get; set; } = string.Empty;
        public int ProjectID { get; set; }
        public int CohortID { get; set; }
        public int UserID { get; set; }
        public int AdminID { get; set; }
    }
}
