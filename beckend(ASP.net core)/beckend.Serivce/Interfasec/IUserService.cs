using beckend.Domain.Models;
using beckend.Domain.Models.dto;
using System.Runtime.CompilerServices;

namespace beckend.Serivce.Interfasec
{
    public interface IUserService
    {
        Task<Answer<UserDto>> GetUserById(Guid id);
        Task<Answer<Guid>> AddUser(User user);
        Task<Answer<UserFullDto>> GetUserFull(Guid id);
        Task<Answer<Guid>> AuthenticateUser(string phone,  string password);
    }
}
