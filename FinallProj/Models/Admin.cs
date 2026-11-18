using FinallProj.Models.Enums;

namespace FinallProj.Models
{
    internal class Admin : User
    {
        public Admin() : base(UserRole.Admin)
        {
        }

        public Admin(int id, string name, string username, string password)
            : base(id, name, username, password, UserRole.Admin)
        {
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"[ADMINI] {Name} | username: {Username}");
        }
    }
}
