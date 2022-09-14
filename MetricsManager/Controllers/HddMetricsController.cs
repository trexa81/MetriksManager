using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsManager.Controllers
{
    [Route("api/hdd")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        [HttpGet("left/agent/{agentId}/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAgent(
            [FromRoute] int agentId,
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }

        [HttpGet("left/all/from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromAll(
            [FromRoute] TimeSpan fromTime,
            [FromRoute] TimeSpan toTime)
        {
            return Ok();
        }
    }
}
