using Expenses.Domain.Abstractions;

namespace Expenses.Domain.Models
{
    public class ExpenseCategory : Entity<int>
    {
        public string Name { get; private set; } = default!;

        public static ExpenseCategory Create(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            return new ExpenseCategory
            {
                Name = name
            };
        }
    }
}
