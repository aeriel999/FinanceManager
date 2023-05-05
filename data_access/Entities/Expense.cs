using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public DateTime Day { get; set; }
        public int CategoryId { get; set; }
        public Category_for_expense category { get; set; }
        public decimal Amount { get; set; }
    }
}
