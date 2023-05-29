using System.ComponentModel.DataAnnotations;

namespace beckend.Domain.Models.dto.User
{
    public class UserDto
    {
        [MaxLength(14)]
        private string firstName = "";
        [MaxLength(14)]
        private string lastName = "";

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
    }
}
