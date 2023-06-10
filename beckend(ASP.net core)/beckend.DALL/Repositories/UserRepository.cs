using beckend.DALL.Interfasec;
using beckend.Domain.Models;
using beckend.Domain.Models.dto.User;
using Microsoft.EntityFrameworkCore;

namespace beckend.DALL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Возвращает Guid пользователя, в случае неудачи возвращает нулевой Guid</returns>
        public async Task<Guid> AddUser(UserRegisterDto? user)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var validNumber = await db.UsersContext.FirstOrDefaultAsync(q => q.PhoneNumber == user.PhoneNumber);

                    if (user != null && validNumber == null)
                    {
                        User rezult = new User();
                        if (user.FirstName != null)
                        {
                            rezult.FirstName = user.FirstName;
                        }
                        else
                        {
                            return new Guid();
                        }
                        if (user.LastName != null)
                        {
                            rezult.LastName = user.LastName;
                        }
                        else
                        {
                            return new Guid();
                        }
                        if (user.Password != null)
                        {
                            rezult.Password = user.Password;
                        }
                        else
                        {
                            return new Guid();
                        }
                        if (user.PhoneNumber != null)
                        {
                            rezult.PhoneNumber = user.PhoneNumber;
                        }
                        else
                        {
                            return new Guid();
                        }
                        // не верно сравнение пустого объекта 
                        if (user.Birthday != new DateTime())
                        {
                            rezult.Birthday = DateTime.SpecifyKind(user.Birthday, DateTimeKind.Utc);
                        }
                        else
                        {
                            return new Guid();
                        }
                        if (user.UrlImage != null)
                        {
                            rezult.UrlImage = user.UrlImage;
                        }
                        else
                        {
                            rezult.UrlImage = null;
                        }

                        rezult.Id = Guid.NewGuid();
                        await db.UsersContext.AddAsync(rezult);
                        await db.SaveChangesAsync();
                        return rezult.Id;
                    }
                    else
                    {
                        throw new Exception("Пользователь с таким телефоном существет");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="password"></param>
        /// <returns>Возвращает Guid пользователя в противном случае возвращает exeption</returns>
        /// <exception cref="Exception"></exception>
        public async Task<Guid> AuthenticateUser(string phone, string password)
        {
            try
            {
                string num = phone;
                using (ApplicationContext db = new ApplicationContext())
                {
                    //var test = await db.UsersContext.FirstOrDefaultAsync(q => q.PhoneNumber != null);
                    var rezult = await db.UsersContext.FirstOrDefaultAsync(q => q.PhoneNumber == num);
                    if(rezult != null)
                    {
                        if (rezult.Password == password)
                        {
                            return rezult.Id;
                        }
                        else
                        {
                            throw new Exception("Пароли не совпадают");
                        }
                    }
                    else
                    {
                        throw new Exception("Пользователь не найден");
                    }
                }
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает информацию о пользователе в противном случае null</returns>
        /// <exception cref="Exception"></exception>
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
                    throw new Exception(ex.Message);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Возвращает фул информацию о пользователе, в противном случае null</returns>
        /// <exception cref="Exception"></exception>
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
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
                throw new Exception(ex.Message);
            }
        }
    }
}
