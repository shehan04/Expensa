using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expenses.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Expenses.Application.Data
{
    public interface IExpensesDbContext
    {
        public DbSet<Expense> Expenses { get; }
        public DbSet<ExpenseItem> ExpenseItems{ get; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; }
        public DbSet<ScheduledExpense> ScheduledExpenses{ get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
