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
    public class ExpenseConfigurataion : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(o => o.Id).HasConversion(
                            expenseId => expenseId.Value,
                            dbId => ExpenseId.Of(dbId));
            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne<ExpeseCategory>()
                .WithMany()
                .HasForeignKey(ec => ec.CategoryId)
                .IsRequired();

            builder.HasMany(e => e.ExpenseItems)
                .WithOne()
                .HasForeignKey(oi => oi.ExpenseId);
        }
    }
}
