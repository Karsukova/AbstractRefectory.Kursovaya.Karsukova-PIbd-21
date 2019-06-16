using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using DB;
using DB.Implementations;
using Unity.Lifetime;
using AbstractRefectoryServiceDAL.Interfaces;

namespace AbstractRefetoryView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, AbstractDbContext>(new
  HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAdminService, AdminServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IProductService, ProductServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrderListService, OrderListServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceDB>(new
           HierarchicalLifetimeManager());
            currentContainer.RegisterType<IFridgeService, FridgeServiceDB>(new
          HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReptService, ReptServiceDB>(new
                      HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
