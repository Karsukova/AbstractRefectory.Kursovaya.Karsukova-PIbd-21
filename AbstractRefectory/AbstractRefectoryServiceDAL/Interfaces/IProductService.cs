using System;
using System.Collections.Generic;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.BindingModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.Interfaces
{
   public interface IProductService
    {
        List<ProductViewModel> GetList();
        ProductViewModel GetElement(int id);
        void AddElement(ProductBindingModel model);
        void UpdElement(ProductBindingModel model);
        void DelElement(int id);
    }
}
