using beckend.Domain.Models;

namespace beckend.Serivce.Interfasec
{
    public interface IUserService
    {
        Task<Answer<User>> GetUserById(Guid id);
        Task<Answer<bool>> AddUser(User user);
    }
}
