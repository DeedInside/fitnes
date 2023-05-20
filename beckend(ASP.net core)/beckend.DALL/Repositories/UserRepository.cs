using beckend.DALL.Interfasec;
using beckend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace beckend.DALL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        private int code = 200;
        private string mes = "операция выполненна успешно";

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUser(User user)
        {
            try{
                user.Birthday = DateTime.UtcNow;
                _context.UsersContext.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<User> GetUser(Guid id)
        {
            try
            {
                return await _context.UsersContext.FirstOrDefaultAsync(q => q.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
