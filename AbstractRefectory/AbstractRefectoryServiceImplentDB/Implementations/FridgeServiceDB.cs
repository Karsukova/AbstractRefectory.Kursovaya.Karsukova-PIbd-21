using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.Implementations
{
    public class FridgeServiceDB : IFridgeService
    {
        private AbstractDbContext context;

        public FridgeServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void AddElement(FridgeBindingModel model)
        {
            Fridge element = context.Fridges.FirstOrDefault(rec => rec.FridgeName == model.FridgeName);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            context.Fridges.Add(new Fridge
            {
                FridgeName = model.FridgeName
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Fridge element = context.Fridges.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Fridges.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public FridgeViewModel GetElement(int id)
        {
            Fridge element = context.Fridges.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new FridgeViewModel
                {
                    Id = element.Id,
                    FridgeName = element.FridgeName,
                    FridgeProducts = context.FridgeProducts
                    .Where(recPC => recPC.FridgeId == element.Id)
                    .Select(recPC => new FridgeProductViewModel
                    {
                        Id = recPC.Id,
                        FridgeId = recPC.FridgeId,
                        ProductId = recPC.ProductId,
                        ProductName = recPC.Product.ProductName,
                        Count = recPC.Count
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<FridgeViewModel> GetList()
        {
            List<FridgeViewModel> result = context.Fridges.Select(rec => new FridgeViewModel
            {
                Id = rec.Id,
                FridgeName = rec.FridgeName
            })
            .ToList();
            return result;
        }

        public void UpdElement(FridgeBindingModel model)
        {
            Fridge element = context.Fridges.FirstOrDefault(rec => rec.FridgeName == model.FridgeName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Fridges.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.FridgeName = model.FridgeName;
            context.SaveChanges();
        }
    }
}
