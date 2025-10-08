using Back_End.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardController : ControllerBase
    {
        private readonly PrimaryServerContext context;

        public AdminDashboardController(PrimaryServerContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OwnerDashBoard>>> GetEmployees()
        {
            var data = await context.OwnerDashBoards.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<OwnerDashBoard>> GetEmployeeById(int Id)
        {
            var Employee = await context.OwnerDashBoards.FindAsync(Id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Employee;
        }
        [HttpPost]
        public async Task<ActionResult<OwnerDashBoard>> AddEmployee(OwnerDashBoard emp)
        {
            await context.OwnerDashBoards.AddAsync(emp);
            await context.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<OwnerDashBoard>> UpdateEmployee(int Id, OwnerDashBoard emp)
        {
            if (Id != emp.Id)
            {
                return BadRequest();
            }
            context.Entry(emp).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return Ok(emp);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<OwnerDashBoard>> DeleteEmployee(int Id)
        {
            var emp = await context.OwnerDashBoards.FindAsync(Id);
            if (emp == null)
            {
                return NotFound();
            }
            context.OwnerDashBoards.Remove(emp);
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("stats")]
        public async Task<ActionResult> GetStats()
        {
            var totalEmployees = await context.OwnerDashBoards.CountAsync();
            var totalSalary = await context.OwnerDashBoards.SumAsync(e => e.Salary);
            var averageSalary = await context.OwnerDashBoards.AverageAsync(e => e.Salary);

            return Ok(new
            {
                totalEmployees,
                totalSalary,
                averageSalary
            });
        }

    }
}
