using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.Services
{
    public interface ISingletonService { Guid Id { get; } }
    public class SingletonService : ISingletonService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
