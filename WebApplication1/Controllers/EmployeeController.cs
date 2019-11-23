using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommonLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SinglePageApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee employee;
        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(EmployeeModel model)
        {
             var result = employee.Register(model);
             return Ok(new { result });
        }
        [HttpPost]
        [Route("update")]
        public string UpdateEmployee(EmployeeModel model)
        {
            var result = this.employee.UpdateEmployee(model);
            return result;
        }

        [HttpPost]
        [Route("delete")]
        public string DeleteEmployee(EmployeeModel model)
        {
            var result = this.employee.DeleteEmployee(model);
            return result;
        }


        [HttpGet]
        [Route("select")]
        public IList<EmployeeModel> DiplayEmployee()
        {
            return this.employee.DisplayEmployee();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public EmployeeModel DisplayById(int id)
        {
            return this.employee.DisplayById(id);
        }

    }
}