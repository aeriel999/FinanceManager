using Microsoft.EntityFrameworkCore;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Income 
    {
       

        public Income(string name)
        {
            Name = name;
        }
        public Income()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime Month { get; set; }
        [NotMapped]
        public bool CanEdit { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }


        public decimal AmountIncom()
        {
            decimal amountIncome = 0;

            amountIncome += Amount;

            return amountIncome;
        }
        public void UpdateAmountIncome()
        {
            Amount = AmountIncom();
        }
        
    }
}
