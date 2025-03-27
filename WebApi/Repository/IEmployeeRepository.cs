using WebApi.DTO;

namespace WebApi.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeesByIdAsync(int EmployeeId);
        Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDto);
        Task<EmployeeDTO> UpdateEmployeeAsync(int id,EmployeeDTO employeeDto);
        Task<bool> DeleteEmployeeAsync(int Id);

    }
}
