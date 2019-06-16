using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractRefectoryModel
{
    public enum OrderStatus
    {
        Принят = 0,
        Выполняется = 1,
        Готов = 2,
        Оплачен = 3
    }
}
