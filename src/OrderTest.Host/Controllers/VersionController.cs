using Microsoft.AspNetCore.Mvc;

namespace OrderTest.Host.Controllers
{
    [ApiController]
    [Route("api/version")]
    public class VersionController : ControllerBase
    {
        [HttpGet]
        public string GetVersion() => "1.0.0.0";
    }
}