using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRefectoryModel;

namespace AbstractRefectoryServiceDAL.BindingModel
{
   public class FridgeProductBindingModel
    {
        public int Id { get; set; }
        public int FridgeId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int FreshDate { get; set; }
        public FreshStatus FreshStatus { get; set; }
        public DateTime? DateNotFresh { get; set; }



    }
}
