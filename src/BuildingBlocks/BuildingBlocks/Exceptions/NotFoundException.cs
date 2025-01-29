using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class NotFoundException :Exception
    {
        public string? Details { get; }
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, string details):base(message)
        {
            Details =details;
        }
    }
}
