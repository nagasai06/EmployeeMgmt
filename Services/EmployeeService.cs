using EmployeeMgmt.Models;
using EmployeeMgmt.Crud;
using EmployeeMgmt.Requests;
using EmployeeMgmt.Responses;
using System.Reflection;

namespace EmployeeMgmt.Services
{
	public class EmployeeService
	{
		private readonly EmployeeCrud _employeeCrud;

		public EmployeeService(EmployeeCrud employeeCrud)
		{
			_employeeCrud = employeeCrud;
		}

		public async Task<EmployeeResponse> Get(Guid id)
		{
			var employee = await _employeeCrud.Get(id);

			var response = new EmployeeResponse
			{
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				DesignationId = employee.DesignationId,
				DesignationDescription = employee.Designation.Description
			};
			return response;
		}
		public async Task<List<EmployeeResponse>> GetAll()
		{
			var employees = await _employeeCrud.GetAll();
			var response = employees.Select(employee => new EmployeeResponse
			{
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				DesignationId= employee.DesignationId,
				DesignationDescription= employee.Designation.Description
			}
			).ToList();
			return response;
		}
		public async Task<List<EmployeeResponse>> Search(String keyword)
		{
			var employees = await _employeeCrud.Search(keyword);
			var response = employees.Select(employee => new EmployeeResponse
			{
				Id = employee.Id,
				FirstName = employee.FirstName,
				LastName = employee.LastName,
				DesignationId = employee.DesignationId,
				DesignationDescription = employee.Designation.Description
			}).ToList();
			return response;
		}
		public async Task<EmployeeResponse> Create(EmployeeRequest employeeRequest)
		{
			var employee = new Employee
			{
				FirstName = employeeRequest.FirstName,
				LastName = employeeRequest.LastName,
				DateofBirth = employeeRequest.DateofBirth,
				Gender = employeeRequest.Gender,
				DesignationId = employeeRequest.DesignationId
			};
			await _employeeCrud.Create(employee);
			var response = await Get(employee.Id);
			return response;
		}
		public async Task<EmployeeResponse> Update(Guid id,  EmployeeRequest employeeRequest)
		{
			var employee = await _employeeCrud.Get(id);
			employee.FirstName = employeeRequest.FirstName;
			employee.LastName = employeeRequest.LastName;
			employee.DateofBirth = employeeRequest.DateofBirth;
			employee.Gender = employeeRequest.Gender;
			employee.DesignationId = employeeRequest.DesignationId;
			await _employeeCrud.Update(employee);
			var response = await Get(employee.Id); 
			return response;
		}
		public async Task Delete(Guid id)
		{
			await _employeeCrud.Delete(id);
		}
	}
}
