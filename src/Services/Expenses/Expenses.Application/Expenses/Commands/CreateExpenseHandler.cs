
using BuildingBlocks.CQRS;
using Expenses.Application.Data;
using Expenses.Application.Dtos;
using Expenses.Domain.Models;

namespace Expenses.Application.Expenses.Commands
{
    public class CreateExpenseHandler(IExpensesDbContext dbContext) : ICommandHandler<CreateExpenseCommand, CreateExpenseResult>
    {
        public async Task<CreateExpenseResult> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var expense = CreateNewExpense(request.Expense);
            dbContext.Expenses.Add(expense);
            await dbContext.SaveChangesAsync(cancellationToken);
            return new CreateExpenseResult(expense.Id.Value);
        }


        public Expense CreateNewExpense(ExpenseDto expenseDto)
        {
            var newExpense = Expense.Create(expenseDto.Name, expenseDto.TransactionDate, expenseDto.TotalAmount,
                expenseDto.CategoryId, expenseDto.DeductedAccount, expenseDto.IsScheduledExpense);

            foreach (var expenseItemDto in expenseDto.ExpenseItems)
            {
                newExpense.Add(expenseItemDto.Description,expenseItemDto.Amount);
            }
            return newExpense;
        }
    }
}
