using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.BindingModel
{
    public class OrderListProductBindingModel
    {
        public int Id { get; set; }
        public int OrderListId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
