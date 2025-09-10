using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Models;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context) => _context = context;

        public async Task<List<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) => await _context.Employees.FindAsync(id);

        public async Task<Employee> CreateAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email, int? id = null)
        {
            return await _context.Employees
                .AnyAsync(e => e.Email == email && (!id.HasValue || e.EmployeeId != id));
        }
    }
}
