using System;
using System.Collections.Generic;
using System.Linq;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryModel;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryImplementList.Implementations
{
    public class FridgeServiceList : IFridgeService
    {
        private DataListSingleton source;
        public FridgeServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<FridgeViewModel> GetList()
        {
            List<FridgeViewModel> result = source.Fridges
            .Select(rec => new FridgeViewModel
            {
                Id = rec.Id,
                FridgeName = rec.FridgeName,
                FridgeProducts = source.FridgeProducts
            .Where(recPC => recPC.FridgeId == rec.Id)
            .Select(recPC => new FridgeProductViewModel
            {
                Id = recPC.Id,
                FridgeId = recPC.FridgeId,
                ProductId = recPC.ProductId,
                ProductName = source.Products
            .FirstOrDefault(recC => recC.Id ==
           recPC.ProductId)?.ProductName,
                Count = recPC.Count
            })
           .ToList()
            })
            .ToList();
            return result;
        }
        public FridgeViewModel GetElement(int id)
        {
            Fridge element = source.Fridges.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new FridgeViewModel
                {
                    Id = element.Id,
                    FridgeName = element.FridgeName,
                    FridgeProducts = source.FridgeProducts
                .Where(recPC => recPC.FridgeId == element.Id).Select(recPC => new FridgeProductViewModel
                {
                    Id = recPC.Id,
                    FridgeId = recPC.FridgeId,
                    ProductId = recPC.ProductId,
                    ProductName = source.Products.FirstOrDefault(recC => recC.Id ==
               recPC.ProductId)?.ProductName,
                    Count = recPC.Count
                })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(FridgeBindingModel model)
        {
            Fridge element = source.Fridges.FirstOrDefault(rec => rec.FridgeName ==
           model.FridgeName);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            int maxId = source.Fridges.Count > 0 ? source.Fridges.Max(rec => rec.Id) : 0;
            source.Fridges.Add(new Fridge
            {
                Id = maxId + 1,
                FridgeName = model.FridgeName
            });
        }
        public void UpdElement(FridgeBindingModel model)
        {
            Fridge element = source.Fridges.FirstOrDefault(rec =>
            rec.FridgeName == model.FridgeName && rec.Id !=
           model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть склад с таким названием");
            }
            element = source.Fridges.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.FridgeName = model.FridgeName;
        }
        public void DelElement(int id)
        {
            Fridge element = source.Fridges.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о компонентах на удаляемом складе
                source.FridgeProducts.RemoveAll(rec => rec.FridgeId == id);
                source.Fridges.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }

        }
    }
}
