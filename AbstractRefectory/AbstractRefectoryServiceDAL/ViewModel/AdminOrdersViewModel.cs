using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractRefectoryServiceDAL.ViewModel
{
    public class AdminOrdersViewModel
    {
        public string CustomerName { get; set; }
        public string DateCreate { get; set; }
        public string OrderListName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
    }
}
