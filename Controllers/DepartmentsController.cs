using Microsoft.AspNetCore.Mvc;
using UserMgtAPI.context.models;

[ApiController]
[Route("api/v1/departments")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _service;

    public DepartmentsController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(DepartmentCreateDto dept)
    {
        var id = await _service.CreateDepartmentAsync(dept);
        return CreatedAtAction(nameof(GetById), new { id = id }, dept);
    }

    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        var user = await _service.GetDepartmentsAsync();
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _service.GetDepartmentByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, DepartmentUpdateDto dept)
    {
        if (id != dept.Id)
        {
            return BadRequest();
        }

        await _service.UpdateDepartmentAsync(dept);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteDepartmentAsync(id);
        return NoContent();
    }
}
