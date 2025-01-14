using Expenses.Domain.Abstractions;
using Expenses.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Domain.Models
{
    public class ExpenseItem : Entity<int>
    {
        public ExpenseItem(ExpenseId expenseId, string description, decimal amount) 
        {
            ExpenseId = expenseId;
            Description = description;
            Amount = amount;
        }
        public ExpenseId ExpenseId { get; private set; } = default!;
        public string Description { get; private set; } = default!;
        public decimal Amount { get; private set; } = default!;

    }
}
