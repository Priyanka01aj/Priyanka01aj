using EmployeeLib.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DITestController: ControllerBase
    {
        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;
        public DITestController(ITransientService transientService1,ITransientService transientService2, IScopedService scopedService1, IScopedService scopedService2, ISingletonService singletonService1, ISingletonService singletonService2)
        {
            _transientService1 = transientService1;
            _transientService2 = transientService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        [HttpGet]
        public IActionResult GetDILife()
        {
            return Ok(new
            {

                Transient = new { Instance1 = _transientService1.Id, Instance2 = _transientService2.Id },
                Scoped = new { Instance1 = _scopedService1.Id, Instance2 = _scopedService2.Id },
                Singleton = new { Instance1 = _singletonService1.Id, Instance2 = _singletonService2.Id }
            });
        }
    }
}
