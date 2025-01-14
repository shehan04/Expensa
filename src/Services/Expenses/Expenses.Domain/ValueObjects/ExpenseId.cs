using Expenses.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Domain.ValueObjects
{
    public record ExpenseId
    {
        public int  Value{ get; }

        private ExpenseId(int value) => Value = value;

        public static ExpenseId Of(int value)
        {
            if (value < 0)
            {
                throw new DomainException("Expense id cannote be empty");
            }
            return new ExpenseId(value);
        }
    }
}
