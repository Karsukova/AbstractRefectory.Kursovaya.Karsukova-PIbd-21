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
    public class OrderListServiceList : IOrderListService
    {
        private DataListSingleton source;
        public OrderListServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<OrderListViewModel> GetList()
        {
            List<OrderListViewModel> result = source.OrderLists.Select(rec => new OrderListViewModel
            {
                Id = rec.Id,
                OrderListName = rec.OrderListName,
                Sum = rec.Sum,
                OrderListProducts = source.OrderListProducts.Where(recPC => recPC.OrderListId == rec.Id)
                .Select(recPC => new OrderListProductViewModel
                {
                    Id = recPC.Id,
                    OrderListId = recPC.OrderListId,
                    ProductId = recPC.ProductId,
                    ProductName = source.Products.FirstOrDefault(recC =>
                   recC.Id == recPC.ProductId)?.ProductName,
                    Count = recPC.Count
                }).ToList()
            }).ToList();
            return result;

        }

        public OrderListViewModel GetElement(int id)
        {
            OrderList element = source.OrderLists.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new OrderListViewModel
                {
                    Id = element.Id,
                    OrderListName = element.OrderListName,
                    Sum = element.Sum,
                    OrderListProducts = source.OrderListProducts.Where(recPC => recPC.OrderListId == element.Id).Select(recPC => new OrderListProductViewModel
                    {
                        Id = recPC.Id,
                        OrderListId = recPC.OrderListId,
                        ProductId = recPC.ProductId,
                        ProductName = source.Products.FirstOrDefault(recC => recC.Id == recPC.ProductId)?.ProductName,
                        Count = recPC.Count
                    })
               .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(OrderListBindingModel model)
        {
            OrderList element = source.OrderLists.FirstOrDefault(rec => rec.OrderListName == model.OrderListName);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            int maxId = source.OrderLists.Count > 0 ? source.OrderLists.Max(rec => rec.Id) :
           0;
            source.OrderLists.Add(new OrderList
            {
                Id = maxId + 1,
                OrderListName = model.OrderListName,
                Sum = model.Sum
            });
            // компоненты для изделия
            int maxPCId = source.OrderListProducts.Count > 0 ?
 source.OrderListProducts.Max(rec => rec.Id) : 0;
            // убираем дубли по компонентам
            var groupComponents = model.OrderListProducts.GroupBy(rec => rec.ProductId).Select(rec => new
            {
                ProductId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });

            // добавляем компоненты
            foreach (var groupMaterial in groupComponents)
            {
                source.OrderListProducts.Add(new OrderListProduct
                {
                    Id = ++maxPCId,
                    OrderListId = maxId + 1,
                    ProductId = groupMaterial.ProductId,
                    Count = groupMaterial.Count
                });
            }
        }
        public void UpdElement(OrderListBindingModel model)
        {
            OrderList element = source.OrderLists.FirstOrDefault(rec => rec.OrderListName ==
model.OrderListName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть изделие с таким названием");
            }
            element = source.OrderLists.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.OrderListName = model.OrderListName;
            element.Sum = model.Sum;
            int maxPCId = source.OrderListProducts.Count > 0 ?
           source.OrderListProducts.Max(rec => rec.Id) : 0;

            // обновляем существуюущие компоненты
            var compIds = model.OrderListProducts.Select(rec =>
 rec.ProductId).Distinct();
            var updateMaterials = source.OrderListProducts.Where(rec => rec.OrderListId ==
           model.Id && compIds.Contains(rec.ProductId));
            foreach (var updateMaterial in updateMaterials)
            {
                updateMaterial.Count = model.OrderListProducts.FirstOrDefault(rec =>
               rec.Id == updateMaterial.Id).Count;
            }
            source.OrderListProducts.RemoveAll(rec => rec.OrderListId == model.Id &&
           !compIds.Contains(rec.ProductId));
            // новые записи
            var groupMaterials = model.OrderListProducts.Where(rec => rec.Id == 0).GroupBy(rec => rec.ProductId)
            .Select(rec => new
            {
                ProductId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });
            foreach (var groupMaterial in groupMaterials)
            {
                OrderListProduct elementPC = source.OrderListProducts.FirstOrDefault(rec
               => rec.OrderListId == model.Id && rec.ProductId == groupMaterial.ProductId);
                if (elementPC != null)
                {
                    elementPC.Count += groupMaterial.Count;
                }
                else
                {

                    source.OrderListProducts.Add(new OrderListProduct
                    {
                        Id = ++maxPCId,
                        OrderListId = model.Id,
                        ProductId = groupMaterial.ProductId,
                        Count = groupMaterial.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            OrderList element = source.OrderLists.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по компонентам при удалении изделия
                source.OrderListProducts.RemoveAll(rec => rec.ProductId == id);
                source.OrderLists.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
