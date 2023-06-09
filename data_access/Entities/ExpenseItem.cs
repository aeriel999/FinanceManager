﻿using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Entities
{
    [AddINotifyPropertyChangedInterface]
    public class ExpenseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public Category_for_expense category { get; set; }

        [NotMapped]
        public bool CanEdit { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }
    }
}
