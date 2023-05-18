using beckend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beckend.Serivce.Interfasec
{
    public interface IUserService
    {
        Task<Answer<User>> GetUserById(Guid id);
        Task<Answer<bool>> AddUser(User user);
    }
}
