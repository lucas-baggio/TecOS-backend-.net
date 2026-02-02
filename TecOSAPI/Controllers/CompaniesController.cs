using Microsoft.AspNetCore.Mvc;
using TecOS.Application.UseCases.Companies.CreateCompany;
using TecOS.Application.UseCases.Companies.DeleteCompany;
using TecOS.Application.UseCases.Companies.GetCompanies;
using TecOS.Application.UseCases.Companies.UpdateCompany;

namespace TecOSAPI.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetPaged(
        [FromServices] GetCompaniesUseCase useCase,
        [FromQuery] int page = 1,
        [FromQuery] int size = 10,
        CancellationToken ct = default)
    {
        var result = await useCase.ExecuteAsync(page, size, ct);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromServices] CreateCompanyUseCase useCase,
        [FromBody] CreateCompanyRequest companyRequest,
        CancellationToken ct = default)
    {
        var result = await useCase.ExecuteAsync(companyRequest, ct);
        return CreatedAtAction(nameof(GetPaged), new { id = result }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        [FromServices] UpdateCompanyUseCase useCase,
        [FromBody] UpdateCompanyRequest companyRequest,
        CancellationToken ct)
    {
        if (id != companyRequest.Id) return BadRequest("ID mismatch");
        
        var result = await useCase.ExecuteAsync(companyRequest, ct);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        [FromServices] DeleteCompanyUseCase useCase,
        CancellationToken ct)
    {
        await useCase.ExecuteAsync(new DeleteCompanyRequest(id), ct);
        return NoContent();
    }
}