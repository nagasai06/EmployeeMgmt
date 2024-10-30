namespace EmployeeMgmt.Models
{
	public class Employee
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }
		public string Gender { get; set; }
		public Designation Designation { get; set; }
		public Guid DesignationId { get; set; }


	}
}
