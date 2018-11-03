using CalcTest.API.Controllers.Base;
using CalcTest.Crosscutting.Interfaces;
using CalcTest.Service.Interfaces;
using CalcTest.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CalcTest.API.Controllers
{
    [ApiVersion("1")]
    public class JurosCompostosController : ApiController
    {
        private readonly IJurosCompostosService _jurosCompostosService;
        private readonly IDomainNotificationManager _domainNotificationManager;

        public JurosCompostosController(IJurosCompostosService jurosCompostosService,
            IDomainNotificationManager domainNotificationManager)
            : base(domainNotificationManager)
        {
            _jurosCompostosService = jurosCompostosService;
            _domainNotificationManager = domainNotificationManager;
        }


        /// <summary>
        /// Calcula o valor dos juros compostos aplicando 1% ao mes dado um intervalo de meses
        /// </summary>
        /// <param name="ValorInicial">Valor inicial para cálculo dos juros compostos</param>
        /// <param name="Meses">Intervalo de meses para cálculo dos juros compostos</param>
        /// <returns>Objeto com o valor final com os juros aplicados</returns>
        /// <response code="200">Se o valor inicial e o meses fornecidos forem válidos.</response>
        /// <response code="400">Se o valor inicial ou meses fornecidos forem inválidos.</response>
        [HttpGet]
        [Route("calculajuros")]
        public IActionResult Get([FromQuery]JurosCompostosInputViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(vm);
            }
            return Response(_jurosCompostosService.Calcular(vm).Result);
        }
    }
}
