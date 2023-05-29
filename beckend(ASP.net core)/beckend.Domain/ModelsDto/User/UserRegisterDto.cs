
namespace beckend.Domain.Models.dto.User
{
    public class UserRegisterDto
    {
        private string? phoneNumber = null;
        private string? firstName = null;
        private string? lastName = null;
        private string? password = null;
        private DateTime birthday = DateTime.Now;
        private string? urlImage = null;

        public UserRegisterDto()
        {

        }
        public UserRegisterDto(string phoneNumber, string firstName, string lastName, string password, DateTime birthday)
        {
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Birthday = birthday;
        }
        public string? PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        public string? LastName { get => lastName; set => lastName = value; }
        public string? Password { get => password; set => password = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string? UrlImage { get => urlImage; set => urlImage = value; }
    }
}
