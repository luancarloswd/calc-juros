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
