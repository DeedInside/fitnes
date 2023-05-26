using beckend.DALL.Interfasec;
using beckend.Domain.Models;
using beckend.Domain.Models.dto;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Guid> AddUser(User user)
        {
            try {
                using (var content = _context) {
                    if (user != null)
                    {
                        Guid NewId = Guid.NewGuid() ;
                        user.Birthday = DateTime.SpecifyKind(user.Birthday, DateTimeKind.Utc);
                        //user.Birthday = DateTime.Parse(user.Birthday);
                        //user.Birthday = DateTime.UtcNow;
                        var validNumber = await content.UsersContext.FirstOrDefaultAsync(q => q.PhoneNumber == user.PhoneNumber);
                        if (validNumber == null){
                            User rezult = new User()
                            {
                                Id = NewId,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Password = user.Password,
                                PhoneNumber = user.PhoneNumber,
                                UrlImage = user.UrlImage,
                                Birthday = user.Birthday
                            };
                            await content.UsersContext.AddAsync(rezult);
                            await content.SaveChangesAsync();
                            return NewId;
                        }
                        else
                        {
                            throw new Exception("пользователь существует");
                        }
                    }
                    else
                    {
                        throw new Exception("нет данных пользователя");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> AuthenticateUser(string phone, string password)
        {
            try
            {
                using (var content = _context)
                {
                    var rezult = await content.UsersContext.FirstOrDefaultAsync(q => q.PhoneNumber == phone);
                    if(rezult.Password == password)
                    {
                        return rezult.Id;
                    }
                    else
                    {
                        throw new Exception("Пароли не совпадают");
                    }
                }
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public async Task<UserDto> GetUser(Guid id)
        {
            using (var content = _context)
            {
                UserDto rezult = new UserDto();
                try
                {
                    var user = await content.UsersContext.FirstOrDefaultAsync(q => q.Id == id);
                    if (user != null)
                    {
                        rezult.FirstName = user.FirstName;
                        rezult.LastName = user.LastName;
                        return rezult;
                    }
                    else
                    {
                        return null;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public async Task<UserFullDto> GetUserInfo(Guid id)
        {
            try
            {

                using (var content = _context)
                {
                    UserFullDto rezult = new UserFullDto();
                    var user = await content.UsersContext.FirstOrDefaultAsync(q => q.Id == id);
                    if (user != null)
                    {
                        rezult.Id = user.Id;
                        rezult.FirstName = user.FirstName;
                        rezult.LastName = user.LastName;
                        rezult.PhoneNumber = user.PhoneNumber;
                        rezult.Birthday = user.Birthday;
                        rezult.UrlImage = user.UrlImage;
                        return rezult;
                    }
                    else
                    {
                        return null;
                    }
                }
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
