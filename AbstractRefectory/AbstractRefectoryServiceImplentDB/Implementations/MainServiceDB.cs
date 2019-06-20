using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using DB;

namespace DB.Implementations
{
    public class MainServiceDB : IMainService
    {
        private AbstractDbContext context;
        public MainServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<OrderViewModel> GetList()
        {
            List<OrderViewModel> result = context.Orders.Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                AdminId = rec.AdminId,
                OrderListId = rec.OrderListId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
           rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
           rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                AdminFIO = rec.Admin.AdminFIO,
                OrderListName = rec.OrderList.OrderListName
            })
            .ToList();
            return result;
        }
        public void CreateOrder(OrderBindingModel model)
        {
            context.Orders.Add(new Order
            {
                AdminId = model.AdminId,
                OrderListId = model.OrderListId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = OrderStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeOrderInWork(OrderBindingModel model)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                    element.Count = 1;
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != OrderStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var orderlistProducts = context.OrderListProducts.Where(rec => rec.OrderListId == element.OrderListId);
                    // списываем
                    foreach (var orderlistProduct in orderlistProducts)
                    {
                        int countInFridges = orderlistProduct.Count * element.Count;
                        var fridgeProducts = context.FridgeProducts.Where(rec =>
                        rec.ProductId == orderlistProduct.ProductId);
                        foreach (var fridgeProduct in fridgeProducts)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (fridgeProduct.Count >= countInFridges)
                            {
                                fridgeProduct.Count -= countInFridges;
                                countInFridges = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countInFridges -= fridgeProduct.Count;
                                fridgeProduct.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countInFridges > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                           orderlistProduct.ProductName + " требуется " + orderlistProduct.Count + ", не хватает " + countInFridges);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = OrderStatus.Выполняется;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Выполняется)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = OrderStatus.Готов;
            context.SaveChanges();
        }
        public void PayOrder(OrderBindingModel model)
        {
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != OrderStatus.Готов)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = OrderStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutProductToFridge(FridgeProductBindingModel model)
        {
           FridgeProduct element = context.FridgeProducts.FirstOrDefault(rec =>
           rec.FridgeId == model.FridgeId && rec.ProductId == model.ProductId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.FridgeProducts.Add(new FridgeProduct
                {
                    FridgeId = model.FridgeId,
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    ReceiptDate =  model.ReceiptDate,
                    FreshDate = model.FreshDate,
                    FreshStatus = model.FreshStatus,
                    DateNotFresh = model.DateNotFresh,
                    Count = model.Count
                   
                });
            }
            context.SaveChanges();
        }


        public void UpdateFridge()
        {
            var fridgeProducts = context.FridgeProducts;

            foreach (var fridgeProduct in fridgeProducts)
            {
                FreshStatus freshStatus = CheckStatus(fridgeProduct);
                fridgeProduct.FreshStatus = freshStatus;
            }

           
            context.SaveChanges();
        }

        public FreshStatus CheckStatus(FridgeProduct element)
        {
            TimeSpan span = DateTime.Now - element.ReceiptDate;
            int relative = span.Days;
            if (relative <= element.FreshDate / 3)
            {
                return FreshStatus.Свежайший;
            }
            if (relative <= (element.FreshDate* 2 / 3))
            {
                return FreshStatus.Нормальный;
            }
           
                return FreshStatus.Истекает;
        }

    }

}
