using Microsoft.AspNetCore.Mvc;
using EmployeeMgmt.Requests;
using EmployeeMgmt.Responses;
using EmployeeMgmt.Services;

namespace EmployeeMgmt.Controllers
{
	[ApiController]
	[Route("Designations")]
	public class DesignationController : ControllerBase
	{
		private readonly DesignationService _designationService;

		public DesignationController(DesignationService designationService)
		{
			_designationService = designationService;
		}
		[HttpGet]
		public async Task<ActionResult<List<DesignationResponse>>> GetAll()
		{
			var response = await _designationService.GetAll();
			return Ok(response);

		}
		[HttpGet("{id}")]
		public async Task<ActionResult<DesignationResponse>> Get(Guid id)
		{
			var response = _designationService.Get(id);
			return Ok(response);
		}
		[HttpPost]
		public async Task<ActionResult<DesignationResponse>> Create([FromBody] DesignationRequest request)
		{
			var response = await _designationService.Create(request);
			return StatusCode(StatusCodes.Status201Created, response);
		}
		[HttpPut("{id}")]
		public async Task<ActionResult<DesignationResponse>> Update(Guid id, [FromBody] DesignationRequest request)
		{
			var response = await _designationService.Update(id, request);
			return Ok(response);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(Guid id)
		{
			await _designationService.Delete(id);
			return NoContent();
		}
	}
}
