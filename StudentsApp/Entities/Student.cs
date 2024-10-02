using System.ComponentModel.DataAnnotations;

namespace FoodBasketApp.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string EnrollmentStatus { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
