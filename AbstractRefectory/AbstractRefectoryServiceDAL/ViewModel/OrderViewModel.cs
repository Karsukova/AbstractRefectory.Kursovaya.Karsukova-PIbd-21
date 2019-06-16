using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.ViewModel
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string AdminFIO { get; set; }
        public int OrderListId { get; set; }
        public string OrderListName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }
        public string DateCreate { get; set; }
        public string DateImplement { get; set; }
    }
}
