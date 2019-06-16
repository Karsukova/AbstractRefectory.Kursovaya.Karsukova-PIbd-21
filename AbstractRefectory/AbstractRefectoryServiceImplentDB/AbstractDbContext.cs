using AbstractRefectoryModel;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DB
{
    public class AbstractDbContext : DbContext
    {


        public AbstractDbContext() : base("RefectoryDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
           System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderList> OrderLists { get; set; }
        public virtual DbSet<OrderListProduct> OrderListProducts { get; set; }
        public virtual DbSet<Fridge> Fridges { get; set; }
        public virtual DbSet<FridgeProduct> FridgeProducts { get; set; }
    }


}
