using beckend.Domain.Models;
using beckend.Serivce.Interfasec;
using Microsoft.AspNetCore.Mvc;

namespace beckend_ASP.net_core_.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [Route("getUserInfo")]
        [HttpGet]
        public async Task<JsonResult> getUserInfo(Guid id)
        {
            var user = await userService.GetUserFull(id);
            return new JsonResult(user);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<JsonResult> addUser(User user)
        {
            try
            {
                if (user.FirstName != null)
                {

                    var answer = await userService.AddUser(user);
                    return new JsonResult(answer);
                }
                else
                {
                    return new JsonResult("error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Route("auteUser")]
        [HttpGet]
        public async Task<JsonResult> auteUser(string phone, string password)
        {

            var user = await userService.AuthenticateUser(phone, password); 
            return new JsonResult(user);
        }
    }
}
