using Microsoft.EntityFrameworkCore;
using EmployeeMgmt.Models;

namespace EmployeeMgmt.Crud
{
	public class DesignationCrud
	{
		private readonly EmployeeMgmtContext _context;

		public DesignationCrud(EmployeeMgmtContext context)
		{
			_context = context;
		}

		public async Task<List<Designation>> GetAll()
		{
			return await _context.Designations.ToListAsync();
		}
		public async Task<Designation> Get(Guid id)
		{
			return await _context.Designations.FindAsync(id);
		}
		public async Task<Designation> Create(Designation designation)
		{
			designation.Id = designation.Id;
			_context.Add(designation);
			await _context.SaveChangesAsync();
			return designation;
		}
		public async Task<Designation> Update(Designation designation)
		{
			_context.Update(designation);
			await _context.SaveChangesAsync();
			return designation;
		}
		public async Task Delete(Guid id)
		{
			var designation = await _context.Designations.FindAsync(id);
			_context.Remove(designation);
			await _context.SaveChangesAsync();
		}
	}
}
