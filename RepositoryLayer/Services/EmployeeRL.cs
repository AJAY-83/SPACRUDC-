using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using CommonLayer.Model;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private static readonly string connectionPath = @"Server=(localDB)\Localhost;Database=EmplyeeDetails;Integrated Security=true;MultipleActiveResultSets=true";

        public string Register(EmployeeModel model)
        {
            try
            {
                using (SqlConnection sqlconnection = new SqlConnection(connectionPath))
                {
                    SqlCommand command = new SqlCommand("spInsertEmployee", sqlconnection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("FullName", model.FullName);
                    command.Parameters.AddWithValue("Email", model.Email);
                    command.Parameters.AddWithValue("Salary", model.Salary);
                    command.Parameters.AddWithValue("Gender", model.Gender);
                    sqlconnection.Open();
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
                   
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    
    }
}
