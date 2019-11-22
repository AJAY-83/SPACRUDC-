using CommonLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IEmployeeRL
    {
        string Register(EmployeeModel model);
        string UpdateEmployee(EmployeeModel model);
        string DeleteEmployee(EmployeeModel model);
        IList<EmployeeModel> DisplayEmployee();
        EmployeeModel DisplayById(int id);
    }
}
