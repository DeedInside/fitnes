using beckend.DALL.Interfasec;
using beckend.Domain.Models;
using beckend.Domain.Models.dto.User;
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

        public async Task<Guid> AddUser(UserRegisterDto user)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (user != null)
                    {
                        Guid NewId = Guid.NewGuid();
                        user.Birthday = DateTime.SpecifyKind(user.Birthday, DateTimeKind.Utc);
                        //user.Birthday = DateTime.Parse(user.Birthday);
                        //user.Birthday = DateTime.UtcNow;
                        var validNumber = await db.UsersContext.FirstOrDefaultAsync(q => q.PhoneNumber == user.PhoneNumber);
                        if (validNumber == null)
                        {
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
                            await db.UsersContext.AddAsync(rezult);
                            await db.SaveChangesAsync();
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
            using (ApplicationContext db = new ApplicationContext())
            {
                UserDto rezult = new UserDto();
                try
                {
                    var user = await db.UsersContext.FirstOrDefaultAsync(q => q.Id == id);
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

                using (ApplicationContext db = new ApplicationContext())
                {
                    UserFullDto rezult = new UserFullDto();
                    var user = await db.UsersContext.FirstOrDefaultAsync(q => q.Id == id);
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

        public async Task<bool> UpdateUser(User? user)
        {
            try
            {
                using(ApplicationContext db = new ApplicationContext())
                {
                    var userCurret = await db.UsersContext.FirstOrDefaultAsync(q => q.Id == user.Id);
                    if (user != null)
                    {
                        if(user.FirstName != userCurret.FirstName && user.FirstName != null)
                        {
                            userCurret.FirstName = user.FirstName;
                        }
                        if(user.LastName != userCurret.LastName && user.LastName != null)
                        {
                            userCurret.LastName = user.LastName;
                        }
                        if(user.Password != userCurret.Password && user.Password != null)
                        {
                            userCurret.Password = user.Password;
                        }
                        if(user.PhoneNumber != userCurret.PhoneNumber && user.PhoneNumber != null)
                        {
                           userCurret.PhoneNumber = user.PhoneNumber;
                        }
                        // сделать проверку на отсутствие времени
                        if(user.Birthday != userCurret.Birthday)
                        {
                            //userCurret.Birthday = user.Birthday;
                        }
                        db.UsersContext.Update(userCurret);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
