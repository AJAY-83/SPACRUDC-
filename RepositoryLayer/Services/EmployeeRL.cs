// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmployeeRL.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Ajay Lodale"/>
// --------------------------------------------------------------------------------------------------------------------

namespace RepositoryLayer.Services
{
    using RepositoryLayer.Interface;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using CommonLayer.Model;

    /// <summary>
    /// EmployeeRL class have the sql server connection 
    /// and have the opearions like delete ,update and  insert
    /// </summary>
    public class EmployeeRL : IEmployeeRL
    {
        /// <summary>
        /// conncetionPath have the server coonection string inside that have configuration
        /// Server is the use as server name 
        /// Database is the name of the database(EmployeeDetails)
        /// Integrated security = true is use for windows authentication user
        /// we cal also use SSPI(Server Security Programming Interface)
        /// </summary>
        private static readonly string connectionPath = @"Server=(localDB)\Localhost;Database=EmplyeeDetails;Integrated Security=true;MultipleActiveResultSets=true";

        /// <summary>
        /// Register method is add the Employee data
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>return to the  BL after finished  </returns>
        public string Register(EmployeeModel model)
        {
            try
            {
                //// when to use using() when we doesn't need to close the database 
                //// it will close automaticaly when work.
                using (SqlConnection sqlconnection = new SqlConnection(connectionPath))
                {
                    //// SqlCommand is to get the sql command that is return inside the store procedure
                    SqlCommand command = new SqlCommand("spInsertEmployee", sqlconnection);

                    //// CommandType is use to get store store procedure and perform operation
                    //// commandType has default  form is text. 
                    command.CommandType = CommandType.StoredProcedure;

                    ////Parameters.AddWithValue get the name as well as value 
                    //// means just store the user data into the database
                    command.Parameters.AddWithValue("FullName", model.FullName);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.Parameters.AddWithValue("Salary", model.Salary);
                    command.Parameters.AddWithValue("Gender", model.Gender);

                    //// make conectin open to inserting the data into the databse
                    sqlconnection.Open();

                    ////Command.ExecuteNonQuery() it is use to store the bunch of data 
                    ///as well when we doing operations again and again with database that time we are mostly use the Execute query
                    
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return "Employee Data Inserted Successfully";
                    }
                    else
                    {
                        return "Employee Data is not Inserted";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Update method is use to update the Employee data
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>updated or not</returns>
        public string UpdateEmployee(EmployeeModel model)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionPath))
                {
                    SqlCommand command = new SqlCommand("spUpdateEmployeeById", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", model.Id);
                    command.Parameters.AddWithValue("FullName", model.FullName);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.Parameters.AddWithValue("Salary", model.Salary);
                    command.Parameters.AddWithValue("Gender", model.Gender);
                    sqlconnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return "Employee Data Updated Successfully";
                    }
                    else
                    {
                        return "Employee Data is not Updated";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// DeleteEmployee method is use to delete the employee
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>return  employee deleted or not</returns>
        public string DeleteEmployee(EmployeeModel model)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionPath))
                {
                    SqlCommand command = new SqlCommand("spDeleteEmployeeById", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id", model.Id);

                    sqlconnection.Open();
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        return "Employee Detail Deleted successfully";
                    }
                    else {
                        return "Employee Detail Not deleted";
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Display method is use to delete the all Employees records
        /// </summary>
        /// <returns>return the employee data</returns>
        public IList<EmployeeModel> DisplayEmployee()
        {
            try
            { 
                using (SqlConnection sqlconnection = new SqlConnection(connectionPath))
                {
                    SqlCommand command = new SqlCommand("spGetEmployee", sqlconnection);
                    List<EmployeeModel> employeeModels = new List<EmployeeModel>();
                    sqlconnection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("Id", model.Id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    
                        while (dataReader.Read())
                        {
                            employeeModels.Add(new EmployeeModel
                            {
                                Id= Convert.ToInt32(dataReader["Id"].ToString()),
                                FullName = dataReader["FullName"].ToString(),
                                Email = dataReader["Email"].ToString(),
                                Salary = Convert.ToInt32(dataReader["Salary"].ToString()),
                                Gender = dataReader["Gender"].ToString()
                            });
                        }
                        return employeeModels;
                    }
                    
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// DisplayEmployeeById  is delete the particular employee
        /// using  the id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>deleted employee</returns>
        public EmployeeModel DisplayById(int id)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionPath))
                {
                    SqlCommand command = new SqlCommand("spGetEmployeeById", sqlconnection);
                   EmployeeModel employeeModels = new EmployeeModel();
                    sqlconnection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("Id",id);
                    SqlDataReader dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            employeeModels.Id = Convert.ToInt32(dataReader["Id"]);
                            employeeModels.FullName = dataReader["FullName"].ToString();
                            employeeModels.Email = dataReader["Email"].ToString();
                            employeeModels.Salary = Convert.ToInt32(dataReader["Salary"].ToString());
                            employeeModels.Gender = dataReader["Gender"].ToString();

                        }
                        return employeeModels;
                    }
                    else {
                        throw new Exception();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    }
}