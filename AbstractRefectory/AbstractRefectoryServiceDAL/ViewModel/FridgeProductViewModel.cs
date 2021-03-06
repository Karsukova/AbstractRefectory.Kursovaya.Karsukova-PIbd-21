﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.ViewModel
{
    public class FridgeProductViewModel
    {
        public int Id { get; set; }
        public int FridgeId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
        public string ReceiptDate { get; set; }
        public int FreshDate { get; set; }
        public string DateNotFresh { get; set; }
        public string FreshStatus { get; set; }

    }
}
