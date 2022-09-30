using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public string Task { get; set; }

        public TaskModel(int id, string task)
        {
            ID = id;
            Task = task;
        }
    }
}
