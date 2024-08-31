using APIwithSQLLite.Data;
using APIwithSQLLite.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIwithSQLLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public EmployeeController(DataContext dataContext) {
            _dataContext = dataContext;
        }
        [HttpGet]
        [Route("getEmp")]
        public async Task<ActionResult<List<Employee>>> getEmp()
        {
            return Ok(await _dataContext.Employees.ToListAsync());

        }

        [HttpPost]
        [Route("addEmp")]
        public async Task<ActionResult> addEmp([FromBody] Employee emp) {
            _dataContext.Add(emp);
            await _dataContext.SaveChangesAsync();
            return Ok();    

        }
        [HttpPost]
        [Route("addEmps")]
        public async Task<ActionResult> addEmps([FromBody] List<Employee> lstemployee)
        {
            foreach (var emp in lstemployee)
            {
                _dataContext.Add(emp);
                await _dataContext.SaveChangesAsync();
            }
            return Ok();
        }
        [HttpDelete]
        [Route("deleteEmp")]
        public async Task<ActionResult> deleteEmp(int empid)
        {
            if (_dataContext.Employees.Any(x => x.EmpID == empid))
            {
                _dataContext.Remove(empid);
                await _dataContext.SaveChangesAsync();
                return Ok();

            }
            else
            {
                return NoContent();
            }

        }

    }
}
