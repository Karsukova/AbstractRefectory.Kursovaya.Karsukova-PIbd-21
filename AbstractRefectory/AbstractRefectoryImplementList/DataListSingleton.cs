using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbstractRefectoryModel;
using System.Threading.Tasks;

namespace AbstractRefectoryImplementList
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Product> Products { get; set; }
        public List<Admin> Admins { get; set; }
        public List<Order> Orders { get; set; }
        public List<Fridge> Fridges { get; set; }
        public List<FridgeProduct> FridgeProducts { get; set; }
        public List<OrderList> OrderLists { get; set; }
        public List<OrderListProduct> OrderListProducts { get; set; }
        private DataListSingleton()
        {
            Admins = new List<Admin>();
            Products = new List<Product>();
            Orders = new List<Order>();
            OrderLists = new List<OrderList>();
            OrderListProducts = new List<OrderListProduct>();
            Fridges = new List<Fridge>();
            FridgeProducts = new List<FridgeProduct>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
