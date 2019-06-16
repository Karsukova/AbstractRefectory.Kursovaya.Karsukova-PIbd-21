using System;
using System.Collections.Generic;
using AbstractRefectoryModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryImplementList.Implementations
{
    public class AdminServiceList : IAdminService
    {
        private DataListSingleton source;
        public AdminServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<AdminViewModel> GetList()
        {
            List<AdminViewModel> result = source.Admins.Select(rec =>
           new AdminViewModel
           {
               Id = rec.Id,
               AdminFIO = rec.AdminFIO
           })
.ToList();

            return result;
        }
        public AdminViewModel GetElement(int id)
        {
            Admin element = source.Admins.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new AdminViewModel
                {
                    Id = element.Id,
                    AdminFIO = element.AdminFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(AdminBindingModel model)
        {
            Admin element = source.Admins.FirstOrDefault(rec => rec.AdminFIO ==
model.AdminFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Admins.Count > 0 ? source.Admins.Max(rec => rec.Id) : 0;
            source.Admins.Add(new Admin
            {
                Id = maxId + 1,
                AdminFIO = model.AdminFIO
            });
        }
        public void UpdElement(AdminBindingModel model)
        {
            Admin element = source.Admins.FirstOrDefault(rec => rec.AdminFIO ==
 model.AdminFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Admins.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.AdminFIO = model.AdminFIO;
        }
        public void DelElement(int id)
        {
            Admin element = source.Admins.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Admins.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}

