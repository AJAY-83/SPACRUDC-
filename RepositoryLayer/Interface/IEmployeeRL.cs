// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEmployeeRL.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Ajay Lodale"/>
// --------------------------------------------------------------------------------------------------------------------

namespace RepositoryLayer.Interface
{
    using CommonLayer.Model;
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// IEmployee Interface for Business Layer use to perform middle ware oerations
    /// </summary>
    public interface IEmployeeRL
    {
       
        /// <summary>
        /// Register method is declared use to Add Employee
        /// work as API(Applicaton Programming Interface)
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>Data Inserted or Not</returns>
        string Register(EmployeeModel model);

        /// <summary>
        /// Upddate Employee method Declared here to update Empployee record
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>updated or not</returns>
        string UpdateEmployee(EmployeeModel model);

        /// <summary>
        /// DeleteEmployee method is use to delete the employee Details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string DeleteEmployee(EmployeeModel model);


        /// <summary>
        /// IList is non-generic collection object that can be individually access by index. 
        /// The IList interface has implemented from two interfaces and they are ICollection and IEnumerable. 
        /// </summary>
        /// <returns>return all rows from database </returns>
        IList<EmployeeModel> DisplayEmployee();

        /// <summary>
        /// DisplayById method is use to display the particular one record
        /// from the database
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>single record</returns>
        EmployeeModel DisplayById(int id);
    }
}
