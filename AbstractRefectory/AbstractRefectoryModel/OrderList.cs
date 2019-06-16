using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractRefectoryModel
{
    //Список поставки
    public class OrderList
    {
        public int Id { get; set; }
        [Required]
        public string OrderListName { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [ForeignKey("OrderListId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("OrderListId")]
        public virtual List<OrderListProduct> OrderListProducts { get; set; }
    }
}
