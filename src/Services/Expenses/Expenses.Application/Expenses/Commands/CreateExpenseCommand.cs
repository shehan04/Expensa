using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BuildingBlocks.CQRS;
using Expenses.Application.Dtos;
using FluentValidation;

namespace Expenses.Application.Expenses.Commands
{
    public record CreateExpenseCommand(ExpenseDto Expense) : ICommand<CreateExpenseResult>;

    public record CreateExpenseResult(int Id);

    public class CreateExpenseCommandValidator : AbstractValidator<CreateExpenseCommand>
    {
        public CreateExpenseCommandValidator()
        {
            RuleFor(x => x.Expense.Name).NotEmpty().WithMessage("Name is required");
        }
    }

}
