using System;
using System.Collections.Generic;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.Interfaces
{
    public interface IAdminService
    {
        List<AdminViewModel> GetList();
        AdminViewModel GetElement(int id);
        void AddElement(AdminBindingModel model);
        void UpdElement(AdminBindingModel model);
        void DelElement(int id);
    }
}
