using CommonLayer.Model;
using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;

namespace BusinessLayer.Services
{
   public class EmployeeBL: IEmployee
    {
        private IEmployeeRL employee;
        public EmployeeBL(IEmployeeRL employee)
        {
            this.employee = employee;
        }
        public string Register(EmployeeModel model)
        {
            if (model != null)
            {
                var result = employee.Register(model);
                return result;
            }
            else
            {
                return "Model is empty";
            }
        }
        public string UpdateEmployee(EmployeeModel model)
        {
            if (model != null)
            {

                var result = employee.UpdateEmployee(model);
                return result;
            }
            else
            {
                return "Model is Empty";
            }
        }
        public string DeleteEmployee(EmployeeModel model)
        {
            if (model != null)
            {
                var result = employee.DeleteEmployee(model);
                return result;
            }
            else {
                return "Model is Empty";
            }
        }
        public IList<EmployeeModel> DisplayEmployee()
        {
            return employee.DisplayEmployee();
        }
        public EmployeeModel DisplayById(int id)
        {
            return employee.DisplayById(id);
        }
    }
}
