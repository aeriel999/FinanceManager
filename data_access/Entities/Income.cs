using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Income 
    {
       
        public int Id { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public decimal Amount { get; set; }
        public int Category_for_IncomeId { get; set; }
        public Category_for_Income Category { get; set; }
        [NotMapped]
        public bool CanEdit { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }



      

    }
}
