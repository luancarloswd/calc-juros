using CalcTest.API.Controllers.Base;
using CalcTest.Crosscutting.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalcTest.API.Controllers
{
    [ApiVersion("1")]
    public class ShowMeTheCode : ApiController
    {
        public ShowMeTheCode(IDomainNotificationManager domainNotificationManager) : base(domainNotificationManager)
        { }


        /// <summary>
        /// Retorna link do repositório com o código do projeto
        /// </summary>
        /// <response code="200">Retorna link do repositório com o código do projeto.</response>
        [Route("showmethecode")]
        [HttpGet]
        public IActionResult Get()
            => Response("https://github.com/luancarloswd/softplayer/");
    }
}
