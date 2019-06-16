using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractRefectoryModel
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        public string AdminFIO { get; set; }
        [ForeignKey("AdminId")]
        public virtual List<Order> Orders { get; set; }
    }
}
