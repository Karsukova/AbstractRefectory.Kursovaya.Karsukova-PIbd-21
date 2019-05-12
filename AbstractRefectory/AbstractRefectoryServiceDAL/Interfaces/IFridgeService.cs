using System;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.Interfaces
{
    public interface IFridgeService
    {
        List<FridgeViewModel> GetList();
        FridgeViewModel GetElement(int id);
        void AddElement(FridgeBindingModel model);
        void UpdElement(FridgeBindingModel model);
        void DelElement(int id);
    }
}
