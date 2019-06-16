using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractRefectoryModel
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<OrderListProduct> OrderListProducts { get; set; }
        [ForeignKey("ProductId")]
        public virtual List<FridgeProduct> FridgeProducts { get; set; }

    }
}
