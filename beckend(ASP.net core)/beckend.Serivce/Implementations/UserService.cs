using beckend.DALL;
using beckend.DALL.Interfasec;
using beckend.Domain.Models;
using beckend.Domain.Models.dto.User;
using beckend.Serivce.Interfasec;

namespace beckend.Serivce.Implementations
{
    public class UserService: IUserService
    {
        private IUserRepository? userRepository;

        public UserService(IUserRepository? userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<Answer<Guid>> AddUser(UserRegisterDto user)
        {
            var answer = new Answer<Guid>();

            if (user != null)
            {
                Guid id = await userRepository.AddUser(user);
                answer.StatusCode = 200;
                answer.Message = "Пользователь успешно добавлен";
                answer.Data = id;
                return  answer;
            }
            else
            {
                answer.StatusCode = 400;
                answer.Message = "ошибка добавления пользователя";
                answer.Data = new Guid();
                return answer;
            }
        }

        public async Task<Answer<Guid>> AuthenticateUser(string phone, string password)
        {
            var answer = new Answer<Guid>();
            if (phone != null && password != null)
            {
                var rez = await userRepository.AuthenticateUser(phone, password);
                if (rez != Guid.Empty)
                {
                    answer.StatusCode = 200;
                    answer.Message = "авторизация успешна";
                    answer.Data = rez;
                    return answer;
                }
                else
                {
                    answer.StatusCode = 400;
                    answer.Message = "авторизация не удалась";
                    answer.Data = rez;
                    return answer;
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public async Task<Answer<UserDto>> GetUserById(Guid id)
        {
            var answer = new Answer<UserDto>();
            var user = await userRepository.GetUser(id);

            if (user != null)
            {
                answer.StatusCode = 200;
                answer.Message = "Пользователь найден";
                answer.Data = user;
                return answer;
            }
            else
            {
                answer.StatusCode = 400;
                answer.Message = "Пользователь не найден";
                answer.Data = null;
                return answer;
            }
            
        }

        public async Task<Answer<UserFullDto>> GetUserFull(Guid id)
        {
            var answer = new Answer<UserFullDto>();
            var user = await userRepository.GetUserInfo(id);

            if (user != null)
            {
                answer.StatusCode = 200;
                answer.Message = "Пользователь найден";
                answer.Data = user;
                return answer;
            }
            else
            {
                answer.StatusCode = 400;
                answer.Message = "Пользователь не найден";
                answer.Data = null;
                return answer;
            }
        }

        public async Task<Answer<bool>> UserUpdate(User user)
        {
            var answer = new Answer<bool>();
            var userNew = await userRepository.UpdateUser(user);
            if (user != null)
            {
                answer.StatusCode = 200;
                answer.Message = "изменения прошли успешно";
                answer.Data = true;
                return answer;
            }
            else
            {
                answer.StatusCode = 400;
                answer.Message = "ошибка внесения изменений";
                answer.Data = false;
                return answer;
            }
        }
    }
}
