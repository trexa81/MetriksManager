﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MetricsAgent.Controllers
{
    [Route("api/metriks/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {

        /// <summary>
        /// Получить статистику по нагрузке на ЦП за период
        /// </summary>
        /// <param name="fromTime">Время начала периода</param>
        /// <param name="toTime">Время окончания периода</param>
        /// <returns></returns>
        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetCpuMetrics(
            [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {

            return Ok();
        }
    }
}
