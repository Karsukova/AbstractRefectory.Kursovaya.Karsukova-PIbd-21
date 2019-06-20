using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.BindingModel
{
    public class FridgeBindingModel
    {
        public int Id { get; set; }
        public string FridgeName { get; set; }
        public List<FridgeProductBindingModel> FridgeProducts { get; set; }
    }
}
