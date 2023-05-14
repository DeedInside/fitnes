using System.Net.Mail;

namespace beckend_ASP.net_core_.Models
{
    public class User
    {
        private Guid id;
        private string email = "";
        private string phoneNumber = "";
        private string firstName = "";
        private string lastName = "";
        private string password = "";
        private DateTime birthday = DateTime.Now;
        private string urlImage = "";
        private BodyParams bodyParams = new BodyParams(0,0);

        public User()
        {

        }
        public User(Guid id, string email, string phoneNumber, string firstName, string lastName, string password, DateTime birthday)
        {
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Birthday = birthday;
        }

        public User(Guid id, string email, string phoneNumber, string firstName, string lastName, string password, DateTime birthday, string urlImage, BodyParams bodyParams)
        {
            Id = id;
            Email = email;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Birthday = birthday;
            UrlImage = urlImage;
            BodyParams = bodyParams;
        }

        public Guid Id { get => id; set => id = value; }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                try{
                    MailAddress mail = new MailAddress(value);
                    if (mail != null)
                    {
                        email = Convert.ToString(mail);
                    }
                    else
                    {
                        throw new Exception("Emal null");
                    }
                }
                catch {
                    throw new Exception("неверно указана почта");
                }
            }
        }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public string UrlImage { get => urlImage; set => urlImage = value; }
        public BodyParams BodyParams { get => bodyParams; set => bodyParams = value; }
    }
}
