using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IEmployee
    {
        string Register(EmployeeModel model);
        string UpdateEmployee(EmployeeModel model);
        string DeleteEmployee(EmployeeModel model);
        IList<EmployeeModel> DisplayEmployee();
        EmployeeModel DisplayById(int id);
    }
}
