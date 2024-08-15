using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppAsyncTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Test : ControllerBase
    {

        [HttpGet]
        [Route("Sync")]
        public IActionResult GetSync()
        {
            Thread.Sleep(1000);
            return Ok();
        }

        [HttpGet]
        [Route("Async")]
        public async Task<IActionResult> GetAsync()
        {
            await Task.Delay(1000);
            return Ok();
        }


    }
}
