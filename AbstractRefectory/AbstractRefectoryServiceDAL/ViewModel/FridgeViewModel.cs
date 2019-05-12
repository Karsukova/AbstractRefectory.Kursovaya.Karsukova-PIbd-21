using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.ViewModel
{
    public class FridgeViewModel
    {
        public int Id { get; set; }
        public string FridgeName { get; set; }
        public List<FridgeProductViewModel> StorageMaterials { get; set; }
    }
}
