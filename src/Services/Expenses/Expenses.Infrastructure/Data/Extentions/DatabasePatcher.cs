using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.Infrastructure.Data.Extentions
{
    public static class DatabasePatcher
    {
        public static async Task InitialiseDatabaseAsync(this Microsoft.AspNetCore.Builder.WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<ExpensesDBContext>();

            context.Database.MigrateAsync().GetAwaiter().GetResult();

            await Task.CompletedTask;
            // await SeedAsync(context);
        }
    }
}
