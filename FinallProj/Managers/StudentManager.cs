using FinallProj.Exceptions;
using FinallProj.Models;

namespace FinallProj.Managers
{
    internal class StudentManager
    {
        private List<User> _users;

        public StudentManager()
        {
            _users = new List<User>();
        }

        public StudentManager(List<User> users)
        {
            _users = users;
        }

        public Student AddStudent(string name, int rollNumber, char grade)
        {
            if (RollNumberExists(rollNumber))
                throw new DuplicateRollNumberException($"Roll number {rollNumber} is already taken!");

            string username = $"s{rollNumber}";
            string password = $"student_{rollNumber}";

            bool usernameTaken = _users.Any(user => string.Equals(user.Username, username, StringComparison.OrdinalIgnoreCase));

            if (usernameTaken)
                throw new DuplicateUsernameException($"Username {username} is already taken!");

            int newId = 1;

            if (_users.Count > 0)
            {
                newId = _users.Max(user => user.Id) + 1;
            }

            Student newStudent = new Student(newId, name, username, password, rollNumber, grade);
            _users.Add(newStudent);

            return newStudent;
        }

        public bool RollNumberExists(int rollNumber)
        {
            return _users
                .OfType<Student>()
                .Any(student => student.RollNumber == rollNumber);
        }

        public List<Student> GetAllStudents()
        {
            return _users
                .OfType<Student>()
                .OrderBy(student => student.RollNumber)
                .ToList();
        }

        public Student FindByRollNumber(int rollNumber)
        {
            foreach (Student student in GetAllStudents())
            {
                if (student.RollNumber == rollNumber)
                {
                    return student;
                }
            }

            throw new NotFoundException($"Student with roll number {rollNumber} not found!");
        }

        public Student UpdateGrade(int rollNumber, char newGrade)
        {
            Student student = FindByRollNumber(rollNumber);
            student.UpdateGrade(newGrade);

            return student;
        }

        public double GetAverageGradePoints()
        {
            List<Student> students = GetAllStudents();

            if (students.Count == 0)
            {
                return 0;
            }

            return students.Average(student => student.GetGradePoints());
        }

        public List<IGrouping<char, Student>> GetStudentsGroupedByGrade()
        {
            return GetAllStudents()
                .GroupBy(student => student.Grade)
                .OrderBy(group => group.Key)
                .ToList();
        }

        public List<Student> GetTopStudents(int count)
        {
            return GetAllStudents()
                .OrderByDescending(student => student.GetGradePoints())
                .ThenBy(student => student.Name)
                .Take(count)
                .ToList();
        }

        public List<Student> GetPassedStudents()
        {
            Predicate<Student> passed = student => student.HasPassed();

            return GetAllStudents().FindAll(passed);
        }

        public List<Student> GetFailedStudents()
        {
            return GetAllStudents().FindAll(student => !student.HasPassed());
        }

        public Student DeleteStudent(int rollNumber)
        {
            Student student = FindByRollNumber(rollNumber);
            _users.Remove(student);

            return student;
        }
    }
}
