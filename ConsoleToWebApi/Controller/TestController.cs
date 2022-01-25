using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebApi.Controller
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("/test/[Action]")]
    public class TestController : ControllerBase
    {
        public string Get()
        {
            return "This is form Test Controller Get()";
        }

        public string Get1()
        {
            return "This is form Test Controller Get1()";
        }
    }
}
