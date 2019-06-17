using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractRefectoryModel
{
    public class FridgeProduct
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
        public virtual Product Product { get; set; }
        public virtual Fridge Fridge { get; set; }
    }
}
