using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib.Services
{
    public interface ITransientService { Guid Id { get; } }

    public class TransientService : ITransientService
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
