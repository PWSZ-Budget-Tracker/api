using Budget_Tracker.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_Tracker.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
        public bool IsDefault { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<Goal> Goals { get; set; }
        public ICollection<Income> Incomes { get; set; }
    }
}
