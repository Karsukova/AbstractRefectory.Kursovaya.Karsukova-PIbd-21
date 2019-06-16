using System;
using System.Collections.Generic;
using System.Text;

using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;

namespace AbstractRefectoryServiceDAL.Interfaces
{
    public interface IReptService
    {
        void SaveOrderListPrice(ReptBindingModel model);
        List<FridgesLoadViewModel> GetFridgesLoad();
        void SaveFridgesLoad(ReptBindingModel model);
        List<AdminOrdersViewModel> GetAdminOrders(ReptBindingModel model);
        void SaveAdminOrders(ReptBindingModel model);
    }
}
