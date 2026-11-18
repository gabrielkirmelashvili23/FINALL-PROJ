using FinallProj.Models.Enums;

namespace FinallProj.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        private string _password = string.Empty;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 8)
                {
                    Console.WriteLine("paroli unda iyos minimum 8 simbolo!");
                }
                else
                {
                    _password = value;
                }
            }
        }

        public UserRole Role { get; private set; }

        public User()
        {
        }

        public User(UserRole role)
        {
            Role = role;
        }

        public User(int id, string name, string username, string password, UserRole role)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Role = role;
        }

        public bool CheckPassword(string password)
        {
            return _password == password;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"[{Id}] {Name} | username: {Username} | roli: {Role}");
        }

        public virtual string ToFileLine()
        {
            return $"{Role}|{Id}|{Name}|{Username}|{Password}";
        }

        public override string ToString()
        {
            return $"[{Id}]: {Name}, {Role}.";
        }
    }
}
