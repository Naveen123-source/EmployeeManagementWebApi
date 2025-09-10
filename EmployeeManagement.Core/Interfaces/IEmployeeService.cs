using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Core.DTOs;

namespace EmployeeManagement.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<EmployeeDto> CreateAsync(EmployeeDto dto);
        Task<EmployeeDto?> UpdateAsync(int id, EmployeeDto dto);
    }
}
