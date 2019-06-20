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
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int AdminId { get; set; }
        [DataMember]
        public int OrderListId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]

        public decimal Sum { get; set; }
        [DataMember]

        public OrderStatus Status { get; set; }
        [DataMember]

        public DateTime DateCreate { get; set; }
        [DataMember]

        public DateTime? DateImplement { get; set; }
        [DataMember]

        public virtual Admin Admin { get; set; }
        [DataMember]

        public virtual OrderList OrderList { get; set; }
    }
}
