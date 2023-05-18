﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beckend.Domain.Models
{
    public class User
    {
        private Guid id;
        private string phoneNumber = "";
        [MaxLength(14)]
        private string firstName = "";
        [MaxLength(14)]
        private string lastName = "";
        [MaxLength(14)]
        private string password = "";
        private DateTime birthday = DateTime.Now;
        private string urlImage = "";

        public User()
        {

        }
        public User(Guid id, string phoneNumber, string firstName, string lastName, string password, DateTime birthday)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Birthday = birthday;
        }

        public User(Guid id, string phoneNumber, string firstName, string lastName, string password, DateTime birthday, string urlImage)
        {
            Id = id;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Birthday = birthday;
            UrlImage = urlImage;
        }

        public Guid Id { get => id; set => id = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string UrlImage { get => urlImage; set => urlImage = value; }
    }
}
