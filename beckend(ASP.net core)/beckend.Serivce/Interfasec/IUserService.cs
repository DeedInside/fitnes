using beckend.Domain.Models;
using beckend.Domain.Models.dto;

namespace beckend.Serivce.Interfasec
{
    public interface IUserService
    {
        Task<Answer<UserDto>> GetUserById(Guid id);
        Task<Answer<bool>> AddUser(User user);
    }
}
