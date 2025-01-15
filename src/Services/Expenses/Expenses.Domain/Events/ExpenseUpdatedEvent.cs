using Expenses.Domain.Abstractions;
using Expenses.Domain.Models;

namespace Expenses.Domain.Events
{
    public record ExpenseUpdatedEvent(Expense expense) : IDomainEvent;
}
