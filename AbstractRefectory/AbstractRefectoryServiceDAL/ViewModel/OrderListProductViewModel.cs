using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.ViewModel
{
    public class OrderListProductViewModel
    {
        public int Id { get; set; }
        public int OrderListId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
    }
}
