using Expenses.Domain.Abstractions;
using Expenses.Domain.Events;
using Expenses.Domain.ValueObjects;

namespace Expenses.Domain.Models
{
    public class Expense : Aggregate<ExpenseId>
    {
        private readonly List<ExpenseItem> _expenseItems = new();
        public IReadOnlyList<ExpenseItem> ExpenseItems => _expenseItems.AsReadOnly();
        public string Name { get; private set; } = default!;
        public DateTime TransactionDate { get; private set; } = default!;

        public Decimal TotalAmount
        {
            get => ExpenseItems.Sum(x => x.Amount);
            private set { }
        }
        public int CategoryId { get; private set; }
        public int DeductedAccount { get; private set; }
        public bool IsScheduledExpense { get; private set; }
        public static Expense Create(string name, DateTime transactionDate, decimal totalAmount, int categoryId, int deductedAccount, bool isScheduledExpense)
        {
            var expense = new Expense
            {
                Name = name,
                TransactionDate = transactionDate,
                TotalAmount = totalAmount,
                CategoryId = categoryId,
                DeductedAccount = deductedAccount,
                IsScheduledExpense = isScheduledExpense
            };
            expense.AddDomainEvents(new ExpenseCreatedEvent(expense));
            return expense;
        }

        public void Update(string name, DateTime transactionDate, decimal totalAmount, int categoryId, int deductedAccount, bool isScheduledExpense)
        {

            Name = name;
            TransactionDate = transactionDate;
            TotalAmount = totalAmount;
            CategoryId = categoryId;
            DeductedAccount = deductedAccount;
            IsScheduledExpense = isScheduledExpense;

            AddDomainEvents(new ExpenseUpdatedEvent(this));
        }

        public void Add(string description, decimal amount)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(description);
            ArgumentOutOfRangeException.ThrowIfNegative(amount);

            var expenseItem = new ExpenseItem(Id, description, amount);
            _expenseItems.Add(expenseItem);

        }
        public void Remove(int id)
        {
            var expenseItem = _expenseItems.FirstOrDefault(x => x.Id == id);
            if (expenseItem is not null)
            {
                _expenseItems.Remove(expenseItem);
            }
        }

    }
}
