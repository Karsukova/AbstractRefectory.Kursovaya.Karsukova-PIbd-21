using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DB.Implementations
{
    public class BackUpServiceDB : IBackupService
    {
        private AbstractDbContext context;

        public BackUpServiceDB(AbstractDbContext context)
        {
            this.context = context;
        }

        public void BackUp()
        {
            var fridges = context.Fridges.ToList();
            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<Fridge>));
            using (FileStream fs = new FileStream("fridges.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, fridges);
            }

            var fridgeProducts = context.FridgeProducts.ToList();
            jsonFormatter = new DataContractJsonSerializer(typeof(List<FridgeProduct>));

            using (FileStream fs = new FileStream("fridgeproducts.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, fridgeProducts);
            }


            var orderLP = context.OrderListProducts.ToList();
            jsonFormatter = new DataContractJsonSerializer(typeof(List<OrderListProduct>));
            using (FileStream fs = new FileStream("orderlistproducts.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, orderLP);
            }

            var orders = context.Orders.ToList();
            jsonFormatter = new DataContractJsonSerializer(typeof(List<Order>));

            using (FileStream fs = new FileStream("orders.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, orders);
            }

            var orderlist = context.OrderLists.ToList();
            jsonFormatter = new DataContractJsonSerializer(typeof(List<OrderList>));

            using (FileStream fs = new FileStream("orderlists.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, orderlist);
            }

            var products = context.Products.ToList();
            jsonFormatter = new DataContractJsonSerializer(typeof(List<Product>));

            using (FileStream fs = new FileStream("products.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, products);
            }

            var admins = context.Admins.ToList();
            jsonFormatter = new DataContractJsonSerializer(typeof(List<Admin>));

            using (FileStream fs = new FileStream("admins.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(fs, admins);
            }
            SendEmail(@"karsukova99@gmail.com", "Бекап БД 'Учет продуктов столовой'", "", new string[] { "fridges.json",
                "fridgeproducts.json",  "orders.json", "orderlistproducts.json", "orderlists.json", "products.json" , "admins.json"});
        }
        

        private void SendEmail(string mailAddress, string subject, string text, string[] attachmentPath)
        {
            System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage();
            SmtpClient smtpClient = null;
            try
            {
                m.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                m.To.Add(new MailAddress(mailAddress));
                m.Subject = subject;
                m.Body = text;
                m.SubjectEncoding = System.Text.Encoding.UTF8;
                m.BodyEncoding = System.Text.Encoding.UTF8;
                foreach (var f in attachmentPath)
                    m.Attachments.Add(new Attachment(f));
                smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new NetworkCredential(
                    ConfigurationManager.AppSettings["MailLogin"],
                    ConfigurationManager.AppSettings["MailPassword"]
                    );
                smtpClient.Send(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                m = null;
                smtpClient = null;
            }
        }
    }
}