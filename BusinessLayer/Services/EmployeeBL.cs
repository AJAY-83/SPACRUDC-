// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeBL.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Ajay Lodale"/>
// --------------------------------------------------------------------------------------------------------------------


namespace BusinessLayer.Services
{
    using CommonLayer.Model;
    using BusinessLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using RepositoryLayer.Interface;
    using RepositoryLayer.Services;

    /// <summary>
    /// EmployeeBL class is emplented by the IEmployee Interface
    /// IEmployee have the add employee and  delete employee methods
    /// </summary>
    public class EmployeeBL: IEmployee
    {
        /// <summary>
        /// EMployee is interface and we have ceated the employee reference of that Interface
        /// </summary>
        private IEmployeeRL employee;

        /// <summary>
        /// Constructor created of EmpoloyeeBL class to initialise the reference of IEmployee 
        /// use for the dependency injection through the constructor
        /// </summary>
        /// <param name="employee"></param>
        public EmployeeBL(IEmployeeRL employee)
        {
            this.employee = employee;
        }

        /// <summary>
        /// Register is the methos work as Add employee data into the database
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>returning the string </returns>
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
    
        /// <summary>
        /// Update employee method is use to update the Employee details
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>return the string updated or not</returns>
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

        /// <summary>
        /// DeleteEmployee method use to delete the employee details 
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>string data deleted or not</returns>
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

        /// <summary>
        /// IList Interface used here to store bunch of data in single list
        /// </summary>
        /// <returns>employee records</returns>
        public IList<EmployeeModel> DisplayEmployee()
        {
            return employee.DisplayEmployee();
        }

        /// <summary>
        /// EmployeeModel use as return because we need only single employee data
        /// so we don't need of IList
        /// Get the value by ID
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>return single employee details</returns>
        public EmployeeModel DisplayById(int id)
        {
            return employee.DisplayById(id);
        }
    }
}
