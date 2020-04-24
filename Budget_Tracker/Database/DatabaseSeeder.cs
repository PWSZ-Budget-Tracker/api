using Budget_Tracker.Enums;
using Budget_Tracker.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budget_Tracker.Database
{
    public class DatabaseSeeder
    {
        public static void SeedData(UserManager<User> userManager, BudgetTrackerContext context)
        {
            SeedUser(userManager);
            SeedCategories(context);
            SeedCurrencies(context);
            SeedExampleData(context);
        }

        public static void SeedUser(UserManager<User> userManager)
        {
            if (!(userManager.Users.Count() > 0) )
            {
                User user = new User
                {
                    UserName = "user@example.com",
                    Email = "user@example.com",
                };

                userManager.CreateAsync(user, "Password123.").Wait();
            }
        }

        public static void SeedCategories(BudgetTrackerContext context)
        {
            if (!(context.Categories.Count() > 0))
            {
                context.Categories.Add(new Category() { Name = "Zakupy Spożywcze", UserId = 1, IsDefault = true, Type = CategoryType.Expenses });
                context.Categories.Add(new Category() { Name = "Transport", UserId = 1, IsDefault = true, Type = CategoryType.Expenses });
                context.Categories.Add(new Category() { Name = "Zakupy", UserId = 1, IsDefault = true, Type = CategoryType.Expenses });
                context.Categories.Add(new Category() { Name = "Rachunki", UserId = 1, IsDefault = true, Type = CategoryType.Expenses });
                context.Categories.Add(new Category() { Name = "Zdrowie", UserId = 1, IsDefault = true, Type = CategoryType.Expenses });
                context.Categories.Add(new Category() { Name = "Zwierzęta", UserId = 1, IsDefault = true, Type = CategoryType.Expenses });
                context.Categories.Add(new Category() { Name = "Rekreacja", UserId = 1, IsDefault = true, Type = CategoryType.Expenses });

                context.Categories.Add(new Category() { Name = "Wypłata", UserId = 1, IsDefault = true, Type = CategoryType.Income });
                context.Categories.Add(new Category() { Name = "Prezenty", UserId = 1, IsDefault = true, Type = CategoryType.Income });

                context.SaveChangesAsync().Wait();
            }
        }

        public static  void SeedCurrencies(BudgetTrackerContext context)
        {
            if (!(context.Currencies.Count() > 0))
            {
                context.Currencies.Add(new Currency() { Name = "Złoty", ShortName = "PLN" });
                context.Currencies.Add(new Currency() { Name = "Dolar", ShortName = "USD" });
                context.Currencies.Add(new Currency() { Name = "Euro", ShortName = "EUR" });
                context.SaveChangesAsync().Wait();
            }
        }

        public static void SeedExampleData(BudgetTrackerContext context)
        {
            var user = context.Users.Include(i => i.Incomes).FirstOrDefault(i => i.Email == "user@example.com");
            if (!(user.Incomes.Count() > 0))
            {
                context.Incomes.Add(new Income() { CategoryId = 1, UserId = user.Id, Amount = 200, CurrencyId = 1 });
                context.Incomes.Add(new Income() { CategoryId = 2, UserId = user.Id, Amount = 300, CurrencyId = 2 });

                context.Expenses.Add(new Expense() { CategoryId = 1, UserId = user.Id, Amount = 200, CurrencyId = 1 });
                context.Expenses.Add(new Expense() { CategoryId = 2, UserId = user.Id, Amount = 300, CurrencyId = 2 });

                context.Goals.Add(new Goal() { Name = "Wakacje", GoalAmount = 1200, UserId = user.Id, CurrencyId = 1 });
                context.SaveChangesAsync();
            }
        }
    }
}
