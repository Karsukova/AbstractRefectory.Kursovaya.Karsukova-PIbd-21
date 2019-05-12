using System;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryImplementList.Implementations
{
    public class MainServiceList : IMainService
    {

        private DataListSingleton source;
        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = source.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                AdminId = rec.AdminId,
                OrderListId = rec.OrderListId,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                AdminFIO = source.Admins.FirstOrDefault(recC => recC.Id ==
               rec.AdminId)?.AdminFIO,
                OrderListName = source.OrderLists.FirstOrDefault(recP => recP.Id ==
              rec.OrderListId)?.OrderListName,
            })
 .ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;
            source.Orders.Add(new Order
            {
                Id = maxId + 1,
                AdminId = model.AdminId,
                OrderListId = model.OrderListId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов на складах
            var orderlistProducts = source.OrderListProducts.Where(rec => rec.OrderListId
           == element.OrderListId);
            foreach (var orderlistProduct in orderlistProducts)
            {
                int countOnStorages = source.FridgeProducts
                .Where(rec => rec.ProductId ==
               orderlistProduct.ProductId)
                .Sum(rec => rec.Count);
                if (countOnStorages < orderlistProduct.Count * element.Count)
                {
                    var materialName = source.Products.FirstOrDefault(rec => rec.Id ==
                   orderlistProduct.ProductId);
                    throw new Exception("Не достаточно компонента " +
                   materialName?.ProductName + " требуется " + (orderlistProduct.Count * element.Count) +
                   ", в наличии " + countOnStorages);
                }
            }
            // списываем
            foreach (var orderlistProduct in orderlistProducts)
            {
                int countOnStorages = orderlistProduct.Count * element.Count;
                var fridgeProducts = source.FridgeProducts.Where(rec => rec.ProductId
               == orderlistProduct.ProductId);
                foreach (var fridgeProduct in fridgeProducts)
                {
                    // компонентов на одном слкаде может не хватать
                    if (fridgeProduct.Count >= countOnStorages)
                    {
                        fridgeProduct.Count -= countOnStorages;
                        break;
                    }
                    else
                    {
                        countOnStorages -= fridgeProduct.Count;
                        fridgeProduct.Count = 0;
                    }
                }

            }
            element.DateImplement = DateTime.Now;
            element.Status = OrderStatus.Выполняется;
        }

        public void FinishOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
        }

        public void PutComponentOnStorage(StorageMaterialBindingModel model)
        {
            StorageMaterial element = source.StorageMaterials.FirstOrDefault(rec =>
rec.StorageId == model.StorageId && rec.MaterialId == model.MaterialId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.StorageMaterials.Count > 0 ?
               source.StorageMaterials.Max(rec => rec.Id) : 0;
                source.StorageMaterials.Add(new StorageMaterial
                {
                    Id = ++maxId,
                    StorageId = model.StorageId,
                    MaterialId = model.MaterialId,
                    Count = model.Count
                });
            }
        }
    }
}
}
