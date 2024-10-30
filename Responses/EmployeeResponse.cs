namespace EmployeeMgmt.Responses
{
	public class EmployeeResponse
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }
		public string Gender { get; set; }
		public string DesignationDescription { get; set; }
		public Guid DesignationId { get; set; }
	}
}
