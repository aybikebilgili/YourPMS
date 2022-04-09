using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourPMS.Models
{
    public class Employees
    {

        [Key]
        public int employeeID { get; set; }

        public string employeeName { get; set; }
        public int age { get; set; }
        public string phoneNo { get; set; }
        public string position { get; set; }

    }
}
