using System;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Implementations
{
    public class OrderListProductSeviceDB
    {
        public class OrderListProductServiceDB : IOrderListProductService
        {
            private AbstractDbContext context;
            public OrderListProductServiceDB(AbstractDbContext context)
            {
                this.context = context;
            }
            public List<OrderListProductViewModel> GetList()
            {
                List<OrderListProductViewModel> result = context.OrderListProducts.Select(rec => new
               OrderListProductViewModel
                {
                    Id = rec.Id,
                    OrderListId = rec.OrderListId,
                    ProductId = rec.ProductId,
                    Price = rec.Price,
                    ProductName = rec.ProductName,
                    Count = rec.Count
                })
                .ToList();
                return result;
            }
            public OrderListProductViewModel GetElement(int id)
            {
                OrderListProduct element = context.OrderListProducts.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    return new OrderListProductViewModel
                    {
                        Id = element.Id,
                        OrderListId = element.OrderListId,
                        ProductId = element.ProductId,
                        Price = element.Price,
                        ProductName = element.ProductName,
                        Count = element.Count

                    };

                }
                throw new Exception("Элемент не найден");
            }
            public void AddElement(OrderListProductBindingModel model)
            {
               // OrderList element = context.OrderLists.FirstOrDefault(rec => rec.OrderListName ==
               //model.OrderListId);
               // if (element != null)
               // {
               //     throw new Exception("Уже есть клиент с таким ФИО");
               // }
               // context.OrderLists.Add(new OrderList
               // {
               //     OrderListName = model.OrderListName
               // });
               // context.SaveChanges();
            }
            public void UpdElement(OrderListProductBindingModel model)
            {
               // Admin element = context.Admins.FirstOrDefault(rec => rec.AdminFIO ==
               //model.AdminFIO && rec.Id != model.Id);
               // if (element != null)
               // {
               //     throw new Exception("Уже есть клиент с таким ФИО");
               // }
               // element = context.Admins.FirstOrDefault(rec => rec.Id == model.Id);
               // if (element == null)
               // {
               //     throw new Exception("Элемент не найден");
               // }
               // element.AdminFIO = model.AdminFIO;
               // context.SaveChanges();
            }
            public void DelElement(int id)
            {
                Admin element = context.Admins.FirstOrDefault(rec => rec.Id == id);
                if (element != null)
                {
                    context.Admins.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
    }
}
