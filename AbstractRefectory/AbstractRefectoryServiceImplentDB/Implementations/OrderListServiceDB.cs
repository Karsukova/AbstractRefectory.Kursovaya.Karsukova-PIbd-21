﻿using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.Implementations
{
    public class OrderListServiceDB : IOrderListService
    {
        private AbstractDbContext context;
        public OrderListServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }
        public List<OrderListViewModel> GetList()
        {
            List<OrderListViewModel> result = context.OrderLists.Select(rec =>
            new OrderListViewModel
            {
                Id = rec.Id,
                OrderListName = rec.OrderListName,
                Sum = rec.Sum,
                OrderListProducts = context.OrderListProducts
            .Where(recPC => recPC.OrderListId == rec.Id)
           .Select(recPC => new OrderListProductViewModel
           {
               Id = recPC.Id,
               OrderListId = recPC.OrderListId,
               ProductId = recPC.ProductId,
               ProductName = recPC.Product.ProductName,
               Count = recPC.Count,
               Sum = recPC.Count * recPC.Product.Price,
               Price = recPC.Product.Price
           })
           .ToList()
            })
            .ToList();
            return result;
        }
        public OrderListViewModel GetElement(int id)
        {
            OrderList element = context.OrderLists.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new OrderListViewModel
                {
                    Id = element.Id,
                    OrderListName = element.OrderListName,
                    Sum = element.Sum,
                    OrderListProducts = context.OrderListProducts.Where(recPC => recPC.OrderListId == element.Id)
                    .Select(recPC => new OrderListProductViewModel
                    {
                        Id = recPC.Id,
                        OrderListId = recPC.OrderListId,
                        ProductId = recPC.ProductId,
                        ProductName = recPC.Product.ProductName,
                        Count = recPC.Count,
                        Sum = recPC.Product.Price * recPC.Count,
                        Price = recPC.Product.Price 
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(OrderListBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    OrderList element = context.OrderLists.FirstOrDefault(rec =>
                   rec.OrderListName == model.OrderListName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть список с таким названием");
                    }
                    element = new OrderList
                    {
                        OrderListName = model.OrderListName,
                        Sum = model.Sum,

                    };
                    context.OrderLists.Add(element);
                    context.SaveChanges();
                    // убираем дубли по компонентам
                    var groupProducts = model.OrderListProducts
                     .GroupBy(rec => rec.ProductId)
                    .Select(rec => new
                    {
                        ProductId = rec.Key,
                        Count = rec.Sum(r => r.Count)
                    });
                    // добавляем компоненты
                    foreach (var groupProduct in groupProducts)
                    {
                        context.OrderListProducts.Add(new OrderListProduct
                        {
                            OrderListId = element.Id,
                            ProductId = groupProduct.ProductId,
                            Count = groupProduct.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void UpdElement(OrderListBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    OrderList element = context.OrderLists.FirstOrDefault(rec =>
                   rec.OrderListName == model.OrderListName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть изделие с таким названием");
                    }
                    element = context.OrderLists.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.OrderListName = model.OrderListName;
                    element.Sum = model.Sum;
                    context.SaveChanges();
                    // обновляем существуюущие компоненты
                    var compIds = model.OrderListProducts.Select(rec =>
                   rec.ProductId).Distinct();
                    var updateProducts = context.OrderListProducts.Where(rec =>
                   rec.ProductId == model.Id && compIds.Contains(rec.ProductId));
                    foreach (var updateProduct in updateProducts)
                    {
                        updateProduct.Count =
                       model.OrderListProducts.FirstOrDefault(rec => rec.Id == updateProduct.Id).Count;
                    }
                    context.SaveChanges();
                    context.OrderListProducts.RemoveRange(context.OrderListProducts.Where(rec =>
                    rec.OrderListId == model.Id && !compIds.Contains(rec.ProductId)));
                    context.SaveChanges();
                    // новые записи
                    var groupProducts = model.OrderListProducts
                    .Where(rec => rec.Id == 0)
                   .GroupBy(rec => rec.ProductId)
                   .Select(rec => new
                   {
                       ProductId = rec.Key,
                       Count = rec.Sum(r => r.Count)
                   });
                    foreach (var groupProduct in groupProducts)
                    {
                        OrderListProduct elementPC =
                       context.OrderListProducts.FirstOrDefault(rec => rec.OrderListId == model.Id &&
                       rec.ProductId == groupProduct.ProductId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupProduct.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.OrderListProducts.Add(new OrderListProduct
                            {
                                OrderListId = model.Id,
                                ProductId = groupProduct.ProductId,
                                Count = groupProduct.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    OrderList element = context.OrderLists.FirstOrDefault(rec => rec.Id ==
                   id);
                    if (element != null)
                    {
                        // удаяем записи по компонентам при удалении изделия
                        context.OrderListProducts.RemoveRange(context.OrderListProducts.Where(rec =>
                        rec.OrderListId == id));
                        context.OrderLists.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}