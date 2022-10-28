using Employee_Management.Data;
using Employee_Management.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Management.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Employee> AddEmployee(NewEmployee employee)
        {
            if (_db != null)
            {
                Employee emp = new Employee()
                {
                    FirstName=employee.FirstName,
                    LastName=employee.LastName,
                    DateOfBirth=employee.DateOfBirth,
                    Age= employee.Age,
                    Gender = employee.Gender,
                    City=employee.City,
                    Country=employee.Country,
                    Address=employee.Address,
                    MobileNumber=employee.MobileNumber,
                    Email=employee.Email
                };
                
                await _db.Employees.AddAsync(emp);
                await _db.SaveChangesAsync();

                return emp;
            }

            return null;
        }

        public async Task<int> DeleteEmployee(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
                return 0;
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return 1;
        }

        public async Task<List<Employee>> GetEmployees()
        {
             return await _db.Employees.ToListAsync();
        }

        public async Task UpdateEmployee(int id,NewEmployee employee)
        {
            if (_db != null)
            {
                var emp = await _db.Employees.FindAsync(id);
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.Age = employee.Age;
                emp.Gender = employee.Gender;
                emp.City = employee.City;
                emp.Country = employee.Country;
                emp.Address = employee.Address;
                emp.MobileNumber = employee.MobileNumber;
                emp.Email = employee.Email;
                _db.Employees.Update(emp);
              
                await _db.SaveChangesAsync();
            }
        }
    }
}
