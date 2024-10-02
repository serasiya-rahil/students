using FoodBasketApp.Entities;

namespace FoodBasketApp.Services
{
    public class StudentService : IStudentService
    {
        public StudentService()
        {
            // Seed with some data:
            _students.Add(new Student() { Id = GetNextId(), EnrollmentStatus = "Part-time", Name = "Bart Simpson" });
            _students.Add(new Student() { Id = GetNextId(), EnrollmentStatus = "Continuing-Ed", Name = "Homer Simpson" });
            _students.Add(new Student() { Id = GetNextId(), EnrollmentStatus = "Full-time", Name = "Lisa Simpson" });
            _students.Add(new Student() { Id = GetNextId(), EnrollmentStatus = "Graduate", Name = "Marge Simpson" });
        }

        public ICollection<string> GetAllStatuses()
        {
            return _statuses.AsReadOnly();
        }

        public int GetNextId()
        {
            return _students.Count + 1;
        }

        public int AddStudent(Student student)
        {
            int newId = GetNextId();
            student.Id = newId;
            _students.Add(student);
            return newId;
        }

        public List<Student> GetAllStudents()
        {
            return _students;
        }

        public Student GetStudentById(int studentId)
        {
            return _students.FirstOrDefault(s => s.Id == studentId);
        }

        public void DeleteStudentById(int studentId)
        {
            var itemToDelete = _students.FirstOrDefault(s => s.Id == studentId);
            _students.Remove(itemToDelete);
        }

        public void UpdateStudent(Student student)
        {
            DeleteStudentById(student.Id);
            _students.Add(student);
        }

        public List<Student> GetStudentsByStatus(string status)
        {
            return _students.Where(s => s.EnrollmentStatus.ToLower() == status.ToLower()).ToList();
        }

        private string[] _statuses = new string[] { "Full-time", "Part-time", "Graduate", "Continuing-Ed" };

        private List<Student> _students = new List<Student>();
    }
}
