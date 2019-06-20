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
    public class FridgeProduct
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int FridgeId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public DateTime ReceiptDate { get; set; }
        [DataMember]
        public int FreshDate { get; set; }
        [DataMember]
        public FreshStatus FreshStatus { get; set; }
        [DataMember]
        public DateTime? DateNotFresh { get; set; }
        [DataMember]
        public virtual Product Product { get; set; }
        [DataMember]
        public virtual Fridge Fridge { get; set; }
    }
}
