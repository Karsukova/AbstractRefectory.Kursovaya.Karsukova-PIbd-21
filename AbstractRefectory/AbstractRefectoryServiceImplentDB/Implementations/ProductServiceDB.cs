using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.SqlServer;
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
                Price = model.Price,
                FreshDate = model.FreshDate
               
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
                    Price = element.Price,
                    FreshDate = element.FreshDate

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
                Price = rec.Price,
                FreshDate = rec.FreshDate
            
            })
            .ToList();
            return result;
        }

        public void UpdElement(ProductBindingModel model)
        {
            Product element = context.Products.FirstOrDefault(rec => rec.ProductName == model.ProductName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть такой продукт");
            }
            element = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ProductName = model.ProductName;
            element.Price = model.Price;
            element.FreshDate = model.FreshDate;
            //element.FreshStatus = model.FreshStatus;
            context.SaveChanges();
        }



        //public string CheckStatus(Product element)
        //{
        //    TimeSpan span = DateTime.Now - element.ReceiptDate;
        //    int relative = span.Days;
        //    if (relative <= element.FreshDate / 3)
        //    {
        //        return FreshStatus.Свежайший.ToString();
        //    }
        //    else if (relative > element.FreshDate * (2 / 3))
        //    {
        //        return FreshStatus.Истекает.ToString();
        //    }
        //    else
        //        return FreshStatus.Нормальный.ToString();
        //}
        //public ProductFreshment CheckStatus(ProductBindingModel element)
        //{
        //    TimeSpan span = DateTime.Now - element.ReceiptDate;
        //    int relative = span.Days;
        //    if (relative <= element.FreshDate / 3)
        //    {
        //        return ProductFreshment.Свежайший;
        //    }
        //    else if (relative > element.FreshDate * (2 / 3))
        //    {
        //        return ProductFreshment.Истекает;
        //    }
        //    else
        //        return ProductFreshment.Нормальный;
        //}

    }
}
