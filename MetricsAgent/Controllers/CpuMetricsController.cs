using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace MetricsAgent.Controllers
{
    [Route("api/metriks/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        #region Services

        private readonly ILogger<CpuMetricsController> _logger;
        //private readonly ICpuMetricsRepository _cpuMetricsRepository;
        #endregion


        public CpuMetricsController(
            //ICpuMetricsRepository cpuMetricsRepository,
            ILogger<CpuMetricsController> logger)
        {
            //_cpuMetricsRepository = cpuMetricsRepository;
            _logger = logger;
        }

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

            _logger.LogInformation("Get cpu metrics call.");
            return Ok();
        }
    }
}
// a. api/metrics/cpu/from/{fromTime}/to/{toTime} [ВЫПОЛНИЛИ ВМЕСТЕ]
// b. api/metrics/dotnet/errors-count/from/{ fromTime}/ to /{ toTime}
// c. api/metrics/network/from/{ fromTime}/ to /{ toTime}
// d. api/metrics/hdd/left/from/{ fromTime}/ to /{ toTime}
// e. api/metrics/ram/available/from/{ fromTime}/ to /{ toTime}