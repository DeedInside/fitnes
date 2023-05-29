using beckend.Domain.Models;
using beckend.Domain.Models.dto.User;

namespace beckend.DALL.Interfasec
{
    public interface IUserRepository
    {
        /// <summary>
        /// </summary>
        /// <param name="id">type id: Guid</param>
        /// <returns>get record user</returns>
        Task<UserDto> GetUser(Guid id);
        /// <summary>
        /// get full information in user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserFullDto> GetUserInfo(Guid id);
        /// <summary>
        /// Authenticate user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns>guid user</returns>
        Task<Guid> AuthenticateUser(string phone, string password);
        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>get Answer(statys code)</returns>
        Task<Guid> AddUser(UserRegisterDto user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>get Answer(statys code)</returns>
        Task<bool> UpdateUser(User user);
    }
}
