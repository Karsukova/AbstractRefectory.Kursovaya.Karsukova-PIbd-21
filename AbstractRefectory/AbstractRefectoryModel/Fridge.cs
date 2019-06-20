using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;


namespace AbstractRefectoryModel
{
    [DataContract]
    public class Fridge
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string FridgeName { get; set; }
        [ForeignKey("FridgeId")]
        public virtual List<FridgeProduct> FridgeProducts { get; set; }
    }
}
