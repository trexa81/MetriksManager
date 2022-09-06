using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriksManager.Controllers
{
    [Route("api/hdd")]
    [ApiController]
    public class HDDmetriksController : ControllerBase
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
// d. api / metrics / hdd / left / from /{ fromTime}/ to /{ toTime}