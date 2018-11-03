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

        [Route("showmethecode")]
        [HttpGet]
        public IActionResult Get()
            => Response("https://github.com/luancarloswd/softplayer/");
    }
}
