using EmployeeManagement.Core.DTOs;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo) => _repo = repo;

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repo.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                EmployeeId = e.EmployeeId, 
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                DateOfBirth = e.DateOfBirth,
                IsActive = e.IsActive
            }).ToList();
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null) return null;
            return new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                DateOfBirth = employee.DateOfBirth,
                IsActive = employee.IsActive
            };
        }

        public async Task<EmployeeDto> CreateAsync(EmployeeDto dto)
        {
            if (await _repo.EmailExistsAsync(dto.Email))
                throw new Exception("Email already exists.");

            var employee = new Employee
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth,
                IsActive = dto.IsActive
            };

            await _repo.CreateAsync(employee);
            return dto;
        }

        public async Task<EmployeeDto?> UpdateAsync(int id, EmployeeDto dto)
        {
            var employee = await _repo.GetByIdAsync(id);
            if (employee == null) return null;

            if (await _repo.EmailExistsAsync(dto.Email, id))
                throw new Exception("Email already exists.");

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.DateOfBirth = dto.DateOfBirth;
            employee.IsActive = dto.IsActive;

            await _repo.UpdateAsync(employee);
            return dto;
        }
    }
}
