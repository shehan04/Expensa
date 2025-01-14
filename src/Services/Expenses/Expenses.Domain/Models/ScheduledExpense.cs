using Expenses.Domain.Abstractions;
using Expenses.Domain.Enums;

namespace Expenses.Domain.Models
{
    public class ScheduledExpense : Entity<int>
    {
        public string Name { get; private set; } = default!;
        public ExpensePeriod ExpensePeriod { get; private set; } = ExpensePeriod.Monthly;
        public ExpenseScheduleType ExpenseScheduleType { get; private set; } = ExpenseScheduleType.OneTime;
        public decimal Percentage { get; private set; } = decimal.Zero;
        public decimal Amount { get; private set; } = decimal.Zero;

        public DateTime StartedDate { get; private set; } = DateTime.UtcNow;
        public DateTime NextExpenseDate { get; private set; } = DateTime.UtcNow;

        public static ScheduledExpense Create(string name, ExpensePeriod expensePeriod, ExpenseScheduleType expenseScheduleType, decimal percentage,decimal amount, DateTime startedDate, DateTime nextExpenseDate)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount);
            return new ScheduledExpense
            {
                Name = name,
                Amount = amount,
                Percentage = percentage,
                ExpensePeriod = expensePeriod,
                ExpenseScheduleType = expenseScheduleType,
                NextExpenseDate = nextExpenseDate,
                Percentage = percentage,
                StartedDate = startedDate,
            };
        }

    }
}
