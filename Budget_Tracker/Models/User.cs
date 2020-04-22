using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Models
{
    public class User : IdentityUser<int>
    { 
        public string Token { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
