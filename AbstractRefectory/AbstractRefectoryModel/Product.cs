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
    public class Product
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string ProductName { get; set; }
        [DataMember]
        [Required]
        public decimal Price { get; set; }
        [DataMember]
        [Required]
        public int FreshDate { get; set; }
        
       [ForeignKey("ProductId")]
        public virtual List<OrderListProduct> OrderListProducts { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<FridgeProduct> FridgeProducts { get; set; }

    }
}
