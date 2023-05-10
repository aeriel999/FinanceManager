using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class Category_for_Income
    {
        private decimal _amountinc;
        public Category_for_Income(string name)
        {
            Name = name;
        }
        public Category_for_Income() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Income> Incomes { get; set; }
        [NotMapped]
        public bool CanEdit { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
        [NotMapped]
        public decimal AmountIncome { get=> AmountIncom(); set=> _amountinc=value; }

        public decimal AmountIncom()
        {
            decimal amountIncome = 0;
            foreach (var income in Incomes)
            {
                amountIncome = income.Amount;
            }
            return amountIncome;
        }



        public void UpdateAmountIncome()
        {
            AmountIncome = AmountIncom();
        }
    }
}
