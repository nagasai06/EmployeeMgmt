using EmployeeMgmt.Crud;
using EmployeeMgmt.Models;
using EmployeeMgmt.Requests;
using EmployeeMgmt.Responses;

namespace EmployeeMgmt.Services
{
	public class DesignationService
	{
		private readonly DesignationCrud _designationCrud;

		public DesignationService(DesignationCrud designationCrud)
		{
			_designationCrud = designationCrud;
		}
		public async Task<DesignationResponse> Get(Guid id)
		{
			var designation = await _designationCrud.Get(id);

			var response = new DesignationResponse
			{
				Id = designation.Id,
				Description = designation.Description
			};
			return response;
		}
		public async Task<List<DesignationResponse>> GetAll()
		{
			var designations = await _designationCrud.GetAll();

			var response = designations.Select(designation => new DesignationResponse
			{
				Id = designation.Id,
				Description= designation.Description

			}).ToList();
			return response;
		}
		public async Task<DesignationResponse> Create(DesignationRequest request)
		{
			var designation = new Designation
			{
				Description = request.Description
			};
			await _designationCrud.Create(designation);
			return new DesignationResponse
			{
				Id = designation.Id,
				Description = request.Description

			};
		}
		public async Task<DesignationResponse> Update(Guid id, DesignationRequest request)
		{
			var designation = await _designationCrud.Get(id);
			designation.Description = request.Description;
			await _designationCrud.Update(designation);

			return new DesignationResponse
			{
				Id = designation.Id,
				Description = request.Description
			};

		}
		public async Task Delete(Guid id)
		{
			await _designationCrud.Delete(id);
		}


		}

}


