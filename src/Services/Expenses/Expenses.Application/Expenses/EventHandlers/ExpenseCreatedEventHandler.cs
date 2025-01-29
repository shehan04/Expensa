using Expenses.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Expenses.Application.Expenses.EventHandlers
{
    internal class ExpenseCreatedEventHandler(ILogger<ExpenseCreatedEventHandler> logger) :INotificationHandler<ExpenseCreatedEvent>
    {
        public Task Handle(ExpenseCreatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain event handled");
            return Task.CompletedTask;
        }
    }
}
