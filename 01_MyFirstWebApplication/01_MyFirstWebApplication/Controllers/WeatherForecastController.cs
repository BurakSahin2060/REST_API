using Microsoft.AspNetCore.Mvc;

namespace _01_MyFirstWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumberController : ControllerBase
    {
        [HttpPut("increment")]
        public ActionResult<int> Increment([FromBody] int number)
        {
            return Ok(number + 1);
        }
    }
}
