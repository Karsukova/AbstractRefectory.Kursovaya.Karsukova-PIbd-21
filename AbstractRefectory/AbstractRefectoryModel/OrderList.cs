using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace AbstractRefectoryModel
{
    //Список поставки
    [DataContract]
    public class OrderList
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        public string OrderListName { get; set; }
        [DataMember]
        [Required]
        public decimal Sum { get; set; }
        [ForeignKey("OrderListId")]
        public virtual List<Order> Orders { get; set; }
        [ForeignKey("OrderListId")]
        public virtual List<OrderListProduct> OrderListProducts { get; set; }
    }
}
