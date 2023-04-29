using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    public class Category_for_Income
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Income> Incomes { get; set; }
    }
}
