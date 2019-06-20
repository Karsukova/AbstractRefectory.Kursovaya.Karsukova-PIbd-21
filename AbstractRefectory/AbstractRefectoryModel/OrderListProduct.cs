using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace AbstractRefectoryModel
{
    [DataContract]
    public class OrderListProduct
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int OrderListId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public decimal? Sum { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public virtual Product Product { get; set; }
        [DataMember]
        public virtual OrderList OrderList { get; set; }
    }
}
