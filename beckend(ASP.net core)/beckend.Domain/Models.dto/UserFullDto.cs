using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beckend.Domain.Models.dto
{
    public class UserFullDto
    {
        private Guid id;
        private string? phoneNumber = null;
        private string? firstName = null;
        private string? lastName = null;
        private DateTime birthday = DateTime.Now;
        private string? urlImage = null;

        public Guid Id { get => id; set => id = value; }
        public string? PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string? FirstName { get => firstName; set => firstName = value; }
        public string? LastName { get => lastName; set => lastName = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string? UrlImage { get => urlImage; set => urlImage = value; }
    }
}
