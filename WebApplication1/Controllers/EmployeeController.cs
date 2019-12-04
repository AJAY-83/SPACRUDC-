// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeController.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Ajay Lodale"/>
// --------------------------------------------------------------------------------------------------------------------


namespace SinglePageApplication.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BusinessLayer.Interface;
    using CommonLayer.Model;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Route[] attribute use the routing the application
    /// EmployeeController have the all controlles over the application
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployee employee;
        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }

        /// <summary>
        /// [HttpPost] is use send the data into the database via server 
        /// Hypertext Transfer Protocol
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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
        public IActionResult DiplayEmployee()
        {
            var result =  this.employee.DisplayEmployee();
            return Ok(new {      });
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public EmployeeModel DisplayById(int id)
        {
            return this.employee.DisplayById(id);
        }

    }
}