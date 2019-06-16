using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using DB;

namespace DB.Implementations
{
    public class ProductServiceDB : IProductService
    {
        private AbstractDbContext context;

        public ProductServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void AddElement(ProductBindingModel model)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.ProductName == model.ProductName);
            if (element != null)
            {
                throw new Exception("Уже есть такой продукт");
            }
            context.Products.Add(new Product
            {
                ProductName = model.ProductName,
                Price = model.Price
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Products.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public ProductViewModel GetElement(int id)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ProductViewModel
                {
                    Id = element.Id,
                    ProductName = element.ProductName,
                    Price = element.Price
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<ProductViewModel> GetList()
        {
            List<ProductViewModel> result = context.Products.Select(rec => new ProductViewModel
            {
                Id = rec.Id,
                ProductName = rec.ProductName,
                Price = rec.Price
            })
            .ToList();
            return result;
        }

        public void UpdElement(ProductBindingModel model)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.ProductName == model.ProductName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ProductName = model.ProductName;
            element.Price = model.Price;
            context.SaveChanges();
        }
    }
}
