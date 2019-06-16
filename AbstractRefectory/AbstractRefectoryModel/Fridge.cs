using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractRefectoryModel
{
    public class Fridge
    {
        public int Id { get; set; }
        [Required]
        public string FridgeName { get; set; }
        [ForeignKey("FridgeId")]
        public virtual List<FridgeProduct> FridgeProducts { get; set; }
    }
}
