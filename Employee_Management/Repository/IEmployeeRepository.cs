using Employee_Management.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Management.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();

        Task<Employee> AddEmployee(NewEmployee employee);

        Task<int> DeleteEmployee(int id);

        Task UpdateEmployee(int id, NewEmployee employee);
    }
}
