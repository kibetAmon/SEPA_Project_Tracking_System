using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSLibrary.Models
{
    internal class UserModel
    {

        public int ID { get; set; }

     
        public string UserID { get; set; }

       
        public string FirstName { get; set; }

     
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    
        public string Password { get; set; }

       
        public string Role { get; set; }

        
        public int CohortID { get; set; }

        public UserModel(string firstname, string lastname, int id)
        {
            FirstName = firstname;
            LastName = lastname;
            ID = id;
        }

        public string Username { get { return FirstName + " " + LastName; } }

    }


}
