using FinallProj.Models.Enums;

namespace FinallProj.Models
{
    internal class Lecturer : User
    {
        public string Subject { get; set; } = string.Empty;

        public Lecturer() : base(UserRole.Lecturer)
        {
        }

        public Lecturer(int id, string name, string username, string password, string subject)
            : base(id, name, username, password, UserRole.Lecturer)
        {
            Subject = subject;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"     sagani: {Subject}");
        }

        public override string ToFileLine()
        {
            return base.ToFileLine() + $"|{Subject}";
        }
    }
}
