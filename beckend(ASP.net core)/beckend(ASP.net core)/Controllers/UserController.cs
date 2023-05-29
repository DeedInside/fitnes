using beckend.Domain.Models;
using beckend.Serivce.Interfasec;
using Microsoft.AspNetCore.Mvc;
using beckend.Domain.Models.dto.User;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает имя и фамилию пользователя</returns>
        [HttpGet, Route("getUser")]
        public async Task<JsonResult> getUser(Guid id)
        {
            var user = await userService.GetUserById(id);
            return new JsonResult(user);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает фул информацию о пользователе</returns>
        [HttpGet, Route("getUserInfo")]
        public async Task<JsonResult> getUserInfo(Guid id)
        {
            var user = await userService.GetUserFull(id);
            return new JsonResult(user);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost, Route("addUser")]
        public async Task<JsonResult> addUser(UserRegisterDto user)
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
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns>Возвращает guid пользователя</returns>
        [HttpGet, Route("auteUser")]
        public async Task<JsonResult> auteUser(string phone, string password)
        {
            var userGuid = await userService.AuthenticateUser(phone, password); 
            return new JsonResult(userGuid);
        }
        /// <summary>
        /// обновление информации о пользователе
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Возвроащает успех или неудачу обновления данных</returns>
        [HttpPut, Route("UpdateUser")]
        public async Task<JsonResult> UpdateUser(User user)
        {
            var answer = await userService.UserUpdate(user);
            return new JsonResult(answer); 
        }
    }
}
