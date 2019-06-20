using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.SqlServer;

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
                throw new Exception("Уже есть холодильник с таким названием");
            }
            context.Fridges.Add(new Fridge
            {
                FridgeName = model.FridgeName,


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
                        Count = recPC.Count,
                        ReceiptDate = SqlFunctions.DateName("dd", recPC.ReceiptDate) + " " +
            SqlFunctions.DateName("mm", recPC.ReceiptDate) + " " +
            SqlFunctions.DateName("yyyy", recPC.ReceiptDate),
                        FreshDate = recPC.FreshDate,
                        DateNotFresh = recPC.DateNotFresh == null ? "" :
            SqlFunctions.DateName("dd",
           recPC.DateNotFresh.Value) + " " +
            SqlFunctions.DateName("mm",
           recPC.DateNotFresh.Value) + " " +
            SqlFunctions.DateName("yyyy",
           recPC.DateNotFresh.Value),
                        FreshStatus = recPC.FreshStatus.ToString()
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
                FridgeName = rec.FridgeName,
                FridgeProducts = context.FridgeProducts
            .Where(recPC => recPC.FridgeId == rec.Id)
           .Select(recPC => new FridgeProductViewModel
           {
               Id = recPC.Id,
               FridgeId = recPC.FridgeId,
               ProductId = recPC.ProductId,
               ProductName = recPC.Product.ProductName,
               Count = recPC.Count,
               ReceiptDate = SqlFunctions.DateName("dd", recPC.ReceiptDate) + " " +
            SqlFunctions.DateName("mm", recPC.ReceiptDate) + " " +
            SqlFunctions.DateName("yyyy", recPC.ReceiptDate),
               FreshDate = recPC.FreshDate,
               DateNotFresh = recPC.DateNotFresh == null ? "" :
            SqlFunctions.DateName("dd",
           recPC.DateNotFresh.Value) + " " +
            SqlFunctions.DateName("mm",
           recPC.DateNotFresh.Value) + " " +
            SqlFunctions.DateName("yyyy",
           recPC.DateNotFresh.Value),
               FreshStatus = recPC.FreshStatus.ToString()
           })
           .ToList()
            })
            .ToList();
            return result;
        }

        public void UpdElement(FridgeBindingModel model)
        {
            Fridge element = context.Fridges.FirstOrDefault(rec => rec.FridgeName == model.FridgeName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть холодильник с таким названием");
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
