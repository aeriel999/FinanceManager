using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public int IncomeCategoryId { get; set; }
        public Category_for_Income category { get; set; }
    }
}
