using Employee_Management.Models;
using Employee_Management.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Employee_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeesController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var employees = await _employeeRepo.GetEmployees();
                if (employees == null)
                {
                    return NotFound();
                }

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewEmployee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var emp = await _employeeRepo.AddEmployee(employee);
                    if (emp != null)
                    {
                        return Ok(emp);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,[FromBody] NewEmployee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeRepo.UpdateEmployee(id,employee);

                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int result = 0;

            try
            {
                result = await _employeeRepo.DeleteEmployee(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
