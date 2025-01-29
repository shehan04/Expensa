using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Application.Dtos
{
    public record ExpenseItemDto(int Id, int ExpenseId, string Description, decimal Amount);

}