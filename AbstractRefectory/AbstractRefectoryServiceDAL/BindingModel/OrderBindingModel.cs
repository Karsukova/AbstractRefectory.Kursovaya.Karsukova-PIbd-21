﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRefectoryServiceDAL.BindingModel
{
    public class OrderBindingModel
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int OrderListId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
