using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Expense
    {
        public Expense(decimal planeAmount, decimal currentAmount)
        {
            PlaneAmount = planeAmount;
            CurrentAmount = currentAmount;
        }

        public Expense() { }

        public int Id { get; set; }
        public DateTime Day { get; set; }
        public decimal PlaneAmount { get; set; }
        public decimal CurrentAmount { get; set; }

    }
}
