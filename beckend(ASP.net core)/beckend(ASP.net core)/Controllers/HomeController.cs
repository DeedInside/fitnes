using beckend.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace beckend_ASP.net_core_.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class HomeController : Controller
    {
        static User user = new(new Guid(), "+7-999-888-77-66", "first", "last", "123", DateTime.UtcNow);
        Answer<User> ans = new Answer<User>()
        {
            StatusCode = 200,
            Message = "OK",
            Data = user
        };
        //readonly Answer<int> answer = new()
        //{
        //    StatusCode = 200,
        //    Message = "OK",
        //    Data = 777
        //};


        [Route("getStatus")]
        [HttpGet]
        public JsonResult GetStatusCode()
        {
            return new JsonResult(ans);
        }



    }
}
