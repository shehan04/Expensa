using Expenses.Domain.Abstractions;

namespace Expenses.Domain.Models
{
    public class ExpeseCategory : Entity<int>
    {
        public string Name { get; private set; } = default!;

        public static ExpeseCategory Create(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name);
            return new ExpeseCategory
            {
                Name = name
            };
        }
    }
}
