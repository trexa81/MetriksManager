using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MetriksManager.Controllers
{
    [Route("api/cpu")]
    [ApiController]
    public class CPUmetriksController : ControllerBase
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
// TODO: Домашнее задание [Пункт 2]
// В проект агента сбора метрик добавьте контроллеры для сбора метрик, аналогичные
// менеджеру сбора метрик.Добавьте методы для получения метрик с агента, доступные по
//следующим путям
// a. api/metrics/cpu/from/{fromTime}/to/{toTime} [ВЫПОЛНИЛИ ВМЕСТЕ]
// b. api/metrics/dotnet/errors-count/from/{fromTime}/to/{toTime}
// c. api/metrics/network/from/{fromTime}/to/{toTime}
// d. api / metrics / hdd / left / from /{ fromTime}/ to /{ toTime}
// e. api / metrics / ram / available / from /{ fromTime}/ to /{ toTime}