using Budget_Tracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Database
{
    public class BudgetTrackerContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public BudgetTrackerContext(DbContextOptions<BudgetTrackerContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
        }
    }
}
