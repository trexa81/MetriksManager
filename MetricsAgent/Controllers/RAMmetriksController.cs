﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram/available")]
    [ApiController]
    public class RAMmetriksController : ControllerBase
    {

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetRamMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {

            return Ok();
        }
    }
}
