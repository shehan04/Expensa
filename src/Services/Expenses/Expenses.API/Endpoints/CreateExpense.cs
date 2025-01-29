using Carter;
using Expenses.Application.Dtos;
using Expenses.Application.Expenses.Commands;
using Mapster;
using MediatR;

namespace Expenses.API.Endpoints
{

    public record CreateExpenseRequest(ExpenseDto Expense);

    public record CreateExpenseResponse(int id);
    public class CreateExpense : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/expense", async (CreateExpenseRequest request, ISender sender) =>
                {
                    var command = request.Adapt<CreateExpenseCommand>();
                    var result = await sender.Send(command);
                    var response = result.Adapt<CreateExpenseResponse>();
                    return Results.Created($"/expense/{response.id}", response);
                }).WithName("Create Expense")
                .Produces<CreateExpenseResponse>(StatusCodes.Status201Created)
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
