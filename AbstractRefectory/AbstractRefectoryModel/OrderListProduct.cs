using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractRefectoryModel
{
    public class OrderListProduct
    {
        public int Id { get; set; }
        public int OrderListId { get; set; }
        public string ProductName { get; set; }
       public decimal Price { get; set; }
        public decimal? Sum { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public virtual Product Product { get; set; }
        public virtual OrderList OrderList { get; set; }
    }
}
