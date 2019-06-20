using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.Interfaces
{
    public interface IOrderListService
    {
        List<OrderListViewModel> GetList();
        OrderListViewModel GetElement(int id);
        void AddElement(OrderListBindingModel model);
        void UpdElement(OrderListBindingModel model);
        void DelElement(int id);
        List<OrderListProductBindingModel> ReadExcel(string FileName);
    }
}
