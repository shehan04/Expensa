using Expenses.Domain.Abstractions;
using Expenses.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Domain.Events
{
    public record ExpenseUpdatedEvent(Expense expense) :IDomainEvent;
}
