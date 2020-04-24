using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public decimal Amount { get; set; } = 0;
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        public decimal GoalAmount { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
