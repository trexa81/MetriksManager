using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriksManager.Controllers
{
    [Route("api/network")]
    [ApiController]
    public class NetworkMetriksController : ControllerBase
    {
        [HttpGet("agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("all/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAll(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
// c. api / metrics / network / from /{ fromTime}/ to /{ toTime}