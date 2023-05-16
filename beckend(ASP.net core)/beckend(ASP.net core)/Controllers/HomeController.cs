using beckend.Domain.Models;
using beckend.Domain.Models.Answer;
using Microsoft.AspNetCore.Mvc;

namespace beckend_ASP.net_core_.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        readonly User user = new(new Guid(), "+7-999-888-77-66", "first", "last", "123", DateTime.Now);
        readonly Answer<int> answer = new()
        {
            StatusCode = 200,
            Message = "OK",
            Data = 777
        };

        [Route("getUser")]
        [HttpGet]
        public JsonResult getUser()
        {
            return new JsonResult(user);
        }
        [Route("getStatus")]
        [HttpGet]
        public JsonResult GetStatusCode()
        {
            return new JsonResult(answer);
        }
        [HttpPut]
        [Route("putStatus")]
        public JsonResult PutStatusCode(User answer)
        {
            User user = answer;
            return new JsonResult(user);
        }


    }
}
