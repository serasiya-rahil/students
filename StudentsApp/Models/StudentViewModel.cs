using FoodBasketApp.Entities;

namespace StudentsApp.Models
{
	public class StudentViewModel
	{
		public ICollection<string>? Status { get; set; }

		public string? ActiveStatus { get; set; }

		public ICollection<Student>? Students { get; set; }

		public Student Student { get; internal set; }
	}
}
