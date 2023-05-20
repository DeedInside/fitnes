using beckend.DALL.Interfasec;
using beckend.Domain.Models;
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

        public async Task<Answer<bool>> AddUser(User user)
        {
            var answer = new Answer<bool>();

            if (user != null)
            {
                await userRepository.AddUser(user);
                answer.StatusCode = 200;
                answer.Message = "Пользователь успешно добавлен";
                answer.Data = true;
                return  answer;
            }
            else
            {
                answer.StatusCode = 400;
                answer.Message = "ошибка добавления пользователя";
                answer.Data = false;
                return answer;
            }
        }

        public async Task<Answer<User>> GetUserById(Guid id)
        {
            var answer = new Answer<User>();

            User user = await userRepository.GetUser(id);
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
    }
}
