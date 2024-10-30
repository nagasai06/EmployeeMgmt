using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.Crud
{
	public class EmployeeMgmtContext : DbContext
	{
		public EmployeeMgmtContext(DbContextOptions<EmployeeMgmtContext> options) : base(options) { }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Designation> Designations { get; set; }

	}
}
