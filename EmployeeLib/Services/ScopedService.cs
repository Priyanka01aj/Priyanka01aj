using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.Services
{
    public interface IScopedService { Guid Id { get; } }
    public class ScopedService : IScopedService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
