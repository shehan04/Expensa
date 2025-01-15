using Expenses.Domain.Models;
using Expenses.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Infrastructure.Data.Configurataions
{
    public class ExpenseItemConfigurataion : IEntityTypeConfiguration<ExpenseItem>
    {
        public void Configure(EntityTypeBuilder<ExpenseItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.ExpenseId).HasConversion(
                expenseId => expenseId.Value, dbId => ExpenseId.Of(dbId));

        }
    }
}
