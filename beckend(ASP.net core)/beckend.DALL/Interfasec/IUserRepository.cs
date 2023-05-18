using beckend.Domain.Models;

namespace beckend.DALL.Interfasec
{
    public interface IUserRepository
    {
        /// <summary>
        /// </summary>
        /// <param name="id">type id: Guid</param>
        /// <returns>get record user</returns>
        Task<User> GetUser(Guid id);
        /// <summary>
        /// </summary>
        /// <param name="user"></param>
        /// <returns>get Answer(statys code)</returns>
        Task<bool> AddUser(User user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>get Answer(statys code)</returns>
        Task<bool> UpdateUser(User user);
    }
}
