using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsyncDemoController: ControllerBase
    {
        // 1. SYNCHRONOUS (Bad/Blocking approach)
        [HttpGet("sync-delay")]
        public IActionResult GetSyncData()
        {
            var stopwatch = Stopwatch.StartNew();

            // Thread.Sleep freezes the current executing thread completely
            System.Threading.Thread.Sleep(3000);

            stopwatch.Stop();
            return Ok(new
            {
                Message = "Synchronous call completed",
                TimeTakenMs = stopwatch.ElapsedMilliseconds
            });
        }

        // 2. ASYNCHRONOUS (Good/Non-blocking approach)
        // Note the 'async' keyword and the 'Task<IActionResult>' return type
        [HttpGet("async-delay")]
        public async Task<IActionResult> GetAsyncData()
        {
            var stopwatch = Stopwatch.StartNew();

            // 'await' pauses this method, releases the thread to handle other traffic, 
            // and resumes right here once Task.Delay(3000) finishes.
            await Task.Delay(3000);

            stopwatch.Stop();
            return Ok(new
            {
                Message = "Asynchronous call completed",
                TimeTakenMs = stopwatch.ElapsedMilliseconds
            });
        }
    }
}
