using FoodBasketApp.Entities;

namespace FoodBasketApp.Services
{
    public interface IStudentService
    {
        public ICollection<string> GetAllStatuses();

        public int GetNextId();

        public int AddStudent(Student foodItem);

        public List<Student> GetAllStudents();

        public Student GetStudentById(int foodItemId);

        public void DeleteStudentById(int foodItemId);

        public void UpdateStudent(Student foodItem);

        public List<Student> GetStudentsByStatus(string category);
    }
}
