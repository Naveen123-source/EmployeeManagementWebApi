using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.DTOs;

namespace backendWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;
        public EmployeesController(IEmployeeService service) => _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _service.GetByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var employee = await _service.CreateAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto.Email }, employee);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeDto dto)
        {
            try
            {
                var employee = await _service.UpdateAsync(id, dto);
                if (employee == null) return NotFound();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
