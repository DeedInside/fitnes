using beckend.Domain.Models;
using beckend.Serivce.Interfasec;
using Microsoft.AspNetCore.Mvc;

namespace beckend_ASP.net_core_.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("getUser")]
        [HttpGet]
        public JsonResult getUser(Guid id)
        {
            var user = userService.GetUserById(id);
            return new JsonResult(user);
        }

        [HttpPost]
        [Route("addUser")]
        public JsonResult addUser(User user)
        {
            var answer = userService.AddUser(user);
            return new JsonResult(answer);
        }
       
    }
}
