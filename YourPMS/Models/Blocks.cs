using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourPMS.Models
{
    public class Blocks
    {
        [Key]

        public int blockID { get; set; }
        public string blockName { get; set; }
    }
}
