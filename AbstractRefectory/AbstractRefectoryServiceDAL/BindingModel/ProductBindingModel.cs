using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractRefectoryModel;

namespace AbstractRefectoryServiceDAL.BindingModel
{
    public class ProductBindingModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int FreshDate { get; set; }
    }
}
