using Expenses.Application.Data;
using Expenses.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Expenses.Infrastructure.Data
{
    public class ExpensesDBContext : DbContext, IExpensesDbContext
    {
        public ExpensesDBContext(DbContextOptions<ExpensesDBContext> options) : base(options){}
        public DbSet<Expense> Expenses => Set<Expense>();
        public DbSet<ExpenseItem> ExpenseItems => Set<ExpenseItem>();
        public DbSet<ExpenseCategory> ExpenseCategories => Set<ExpenseCategory>();
        public DbSet<ScheduledExpense> ScheduledExpenses => Set<ScheduledExpense>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); 
            base.OnModelCreating(builder);
        }
    }
}
