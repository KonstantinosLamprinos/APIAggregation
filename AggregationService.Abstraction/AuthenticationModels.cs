using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationService.Abstraction
{
    public class AuthenticationModels
    {
        public record LoginRequest(string Username, string Password);
    }
}
