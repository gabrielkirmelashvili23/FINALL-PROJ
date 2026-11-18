using FinallProj.Exceptions;
using FinallProj.Models.Enums;

namespace FinallProj.Models
{
    internal class Student : User
    {
        public static char[] ValidGrades { get; private set; } = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };

        public int RollNumber { get; private set; }

        public char Grade { get; private set; }

        public Student() : base(UserRole.Student)
        {
        }

        public Student(int id, string name, string username, string password, int rollNumber, char grade)
            : base(id, name, username, password, UserRole.Student)
        {
            RollNumber = rollNumber;
            UpdateGrade(grade);
        }

        public static bool IsValidGrade(char grade)
        {
            foreach (char validGrade in ValidGrades)
            {
                if (validGrade == grade)
                {
                    return true;
                }
            }

            return false;
        }

        public void UpdateGrade(char newGrade)
        {
            if (!IsValidGrade(newGrade))
                throw new InvalidGradeException($"Grade must be one of: {string.Join(", ", ValidGrades)}!");

            Grade = newGrade;
        }

        public bool HasPassed()
        {
            return Grade != 'F';
        }

        public int GetGradePoints()
        {
            int points = Grade switch
            {
                'A' => 5,
                'B' => 4,
                'C' => 3,
                'D' => 2,
                'E' => 1,
                _ => 0
            };

            return points;
        }

        public override void ShowInfo()
        {
            string status = "chaabara";

            if (!HasPassed())
            {
                status = "ver chaabara";
            }

            Console.WriteLine($"[N{RollNumber}] {Name} | shefaseba: {Grade} | {status}");
        }

        public override string ToFileLine()
        {
            return base.ToFileLine() + $"|{RollNumber}|{Grade}";
        }
    }
}
