using beckend.Domain.Models;
using beckend.Serivce.Interfasec;
using Microsoft.AspNetCore.Mvc;

namespace beckend_ASP.net_core_.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("getUser")]
        [HttpGet]
        public async Task<JsonResult> getUser(Guid id)
        {
            var user = await userService.GetUserById(id);
            return new JsonResult(user);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<JsonResult> addUser(User user)
        {
            try
            {
                var answer = await userService.AddUser(user);
                return new JsonResult(answer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
