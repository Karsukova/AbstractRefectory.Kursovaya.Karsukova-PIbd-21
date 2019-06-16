using System;
using System.Collections.Generic;
using System.Linq;

using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.Interfaces
{
    public interface IOrderListProductService
    {
        List<OrderListProductViewModel> GetList();
        OrderListProductViewModel GetElement(int id);
        void AddElement(OrderListProductBindingModel model);
        void UpdElement(OrderListProductBindingModel model);
        void DelElement(int id);
    }
}
