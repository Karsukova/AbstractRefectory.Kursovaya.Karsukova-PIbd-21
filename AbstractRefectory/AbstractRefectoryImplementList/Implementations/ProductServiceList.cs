using System;
using System.Collections.Generic;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryImplementList.Implementations
{
    public class ProductServiceList : IProductService
    {
        private DataListSingleton source;
        public ProductServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ProductViewModel> GetList()
        {
            List<ProductViewModel> result = source.Products.Select(rec =>
            new ProductViewModel
            {
                Id = rec.Id,
                ProductName = rec.ProductName,
                Price = rec.Price
            })
  .ToList();

            return result;
        }
        public ProductViewModel GetElement(int id)
        {
            Product element = source.Products.FirstOrDefault(rec => rec.Id == id);
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

        public void AddElement(ProductBindingModel model)
        {
            Product element = source.Products.FirstOrDefault(rec => rec.ProductName
== model.ProductName);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            int maxId = source.Products.Count > 0 ? source.Products.Max(rec =>
           rec.Id) : 0;
            source.Products.Add(new Product
            {
                Id = maxId + 1,
                ProductName = model.ProductName,
                Price = model.Price
            });
        }
        public void UpdElement(ProductBindingModel model)
        {
            Product element = source.Products.FirstOrDefault(rec => rec.ProductName
 == model.ProductName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            element = source.Products.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.ProductName = model.ProductName;
        }


        public void DelElement(int id)
        {
            Product element = source.Products.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Products.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}

