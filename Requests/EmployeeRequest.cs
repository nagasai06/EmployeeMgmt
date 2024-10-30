namespace EmployeeMgmt.Requests
{
	public class EmployeeRequest
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateofBirth { get; set; }
		public string Gender { get; set; }
		public Guid DesignationId { get; set; }
	}
}
