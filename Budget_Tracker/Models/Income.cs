using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Budget_Tracker.Models
{
    public class Income
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}
