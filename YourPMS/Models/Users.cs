using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourPMS.Models
{
    public class Users
    {

        [Key]
        public int userID { get; set; }

        public int blockID { get; set; }
        public string nameSurname { get; set; }
        public int numberOfPeople { get; set; }
        public string phoneNo { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isTenant { get; set; }
        public bool hasCar { get; set; }
        public bool isManager { get; set; }


    }
}
