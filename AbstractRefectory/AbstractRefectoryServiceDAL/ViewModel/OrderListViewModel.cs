using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.ViewModel
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public string OrderListName { get; set; }
        public decimal Sum { get; set; }
        public List<OrderListProductViewModel> OrderListProducts { get; set; }
    }
}
