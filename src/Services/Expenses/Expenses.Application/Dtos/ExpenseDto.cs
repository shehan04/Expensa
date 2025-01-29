using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Application.Dtos
{
    public record ExpenseDto(int Id, string Name, DateTime TransactionDate, Decimal TotalAmount, int CategoryId,
        int DeductedAccount, bool IsScheduledExpense
        , List<ExpenseItemDto> ExpenseItems);
}
