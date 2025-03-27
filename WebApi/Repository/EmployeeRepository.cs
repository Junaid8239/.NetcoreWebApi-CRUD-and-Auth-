using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Data;
using WebApi.DTO;
using WebApi.Mappings;
using WebApi.Models;

namespace WebApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employees = await _context.Employee.ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeesByIdAsync(int EmployeeId)
        {
            var employees = await _context.Employee.FirstOrDefaultAsync(x => x.Id == EmployeeId);
            return _mapper.Map<EmployeeDTO>(employees);
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDto)
        {
            var employee = _mapper.Map<EmployeeModel>(employeeDto);
            await _context.Employee.AddAsync(employee);
            await _context.SaveChangesAsync(); 
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<EmployeeDTO> UpdateEmployeeAsync(int Id,EmployeeDTO employeeDto)
        {

            var employee = await _context.Employee.FindAsync(Id); 
            if (employee == null)
            {
                return null; 
            }

            _mapper.Map(employeeDto, employee);
            employee.Id = Id;
            _context.Employee.Update(employee); 
            await _context.SaveChangesAsync(); 
            return _mapper.Map<EmployeeDTO>(employee); 
        }

        public async Task<bool> DeleteEmployeeAsync(int Id)
        {
            var employee = await _context.Employee.FindAsync(Id); 
            if (employee == null)
            {
                return false;
            }
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }




    }
}
