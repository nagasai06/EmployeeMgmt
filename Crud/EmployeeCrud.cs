using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.Crud
{
	public class EmployeeCrud
	{
		private readonly EmployeeMgmtContext _context;
		public EmployeeCrud(EmployeeMgmtContext context)
		{
			_context = context;
		}
		public async Task<List<Employee>> GetAll()
		{
			return await _context.Employees.Include(x => x.Designation).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToListAsync();
		}
		public async Task<Employee> Get(Guid id)
		{
			return await _context.Employees.Include(x => x.Designation).FirstOrDefaultAsync(x => x.Id ==id);
		}
		public async Task<List<Employee>> Search(String keyword)
		{
			return await _context.Employees.Include(x=>x.Designation).Where(x => x.FirstName.Contains(keyword) || x.LastName.Contains(keyword)).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToListAsync();
		}
		public async Task<Employee> Create(Employee employee)
		{
			employee.Id = Guid.NewGuid();
			_context.Employees.Add(employee);
			await _context.SaveChangesAsync();
			return employee;
		}
		public async Task<Employee> Update(Employee employee)
		{
			_context.Update(employee);
			await _context.SaveChangesAsync();
			return employee;
		}
		public async Task Delete(Guid id)
		{
			var employee = await _context.Employees.FindAsync(id);
			_context.Employees.Remove(employee);
			await _context.SaveChangesAsync();
		}
	}
}
