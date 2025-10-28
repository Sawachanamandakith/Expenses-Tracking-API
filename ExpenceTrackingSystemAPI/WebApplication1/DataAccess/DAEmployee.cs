//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Net.NetworkInformation;
//using WebApplication1.Database_Layer;
//using WebApplication1.Interfaces;
//using WebApplication1.Models;
//using WebApplication1.Models.RequestApiModels;

//namespace WebApplication1.DataAccess
//{
//    public class DAEmployee : IEmployee
//    {
//        private readonly string ProcedureName = "sp_Employee"; // stored procedure
        

//        //post

//        public Response AddEmployee(EmployeeModel employee)
//        {
//            Response result = new Response();

//            string query = @"INSERT INTO [Employee].[dbo].[Employee]
//                     (Name,
//                        Email,
//                        Division,
//                        Department,
//                        Location,
//                        Designation, 
//                        Education,
//                        JoinDate, 
//                        Status)

//                     VALUES (@Name, 
//                            @Email,
//                            @Division,
//                            @Department,
//                            @Location,
//                            @Designation,
//                            @Education,
//                            GETDATE(),
//                            @Status)";

//            try
//            {
//                using (var dbConnect = new DBconnect())
//                using (SqlConnection conn = dbConnect.GetOpenConnection())
//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                {
//                    cmd.Parameters.AddWithValue("@Name", employee.Name);
//                    cmd.Parameters.AddWithValue("@Email", employee.Email);
//                    cmd.Parameters.AddWithValue("@Division", employee.Division);
//                    cmd.Parameters.AddWithValue("@Department", employee.Department);
//                    cmd.Parameters.AddWithValue("@Location", employee.Location);
//                    cmd.Parameters.AddWithValue("@Designation", employee.Designation);
//                    cmd.Parameters.AddWithValue("@Education", employee.Education);
//                    //cmd.Parameters.AddWithValue("@JoinDate", employee.JoinDate);
//                    cmd.Parameters.AddWithValue("@Status", employee.Status);

//                    int rowsAffected = cmd.ExecuteNonQuery();
//                    result.StatusCode = rowsAffected > 0 ? 200 : 500;
//                    result.Result = rowsAffected > 0 ? "Employee added successfully!" : "Insert failed.";
//                }
//            }
            
//            catch (Exception ex)
//            {
//                result.StatusCode = 500;
//                result.Result = "Error: " + ex.Message;
//            }

//            return result;
//        }


       



//        public Response UpdateEmployee(EmployeeModel employee)
//        {
//            Response result = new Response();
//            UserRequestAPI requestAPI = new UserRequestAPI
//            {
//                ActionType = "UPDATE",
//                Id = employee.Id,
//                Name = employee.Name,
//                Email = employee.Email,
//                Division = employee.Division,
//                Department = employee.Department,
//                Location = employee.Location,
//                Designation = employee.Designation,
//                Education = employee.Education,
//                JoinDate = employee.JoinDate,
//                Status = employee.Status
//            };

//            using (var dbConnect = new DBconnect())
//            {
//                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
//                result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
//                result.Result = res.Result;
//            }
//            return result;
//        }

//        public Response DeleteEmployee(UserRequestAPI requestAPI)
//        {
//            Response result = new Response();
//            requestAPI.ActionType = "DELETE";

//            using (var dbConnect = new DBconnect())
//            {
//                ProcedureDBModel res = dbConnect.ProcedureRead(requestAPI, ProcedureName);
//                result.StatusCode = res.ResultStatusCode == "1" ? 200 : 500;
//                result.Result = res.Result;
//            }
//            return result;
//        }
//        //get
//        public Response GetAllEmployees(UserRequestAPI requestAPI)
//        {
//            Response result = new Response();
//            List<EmployeeModel> employees = new List<EmployeeModel>();

//            string query = @"SELECT Id, Name, Email, Division, Department, 
//                            Location, Designation, Education, JoinDate, Status
//                     FROM Employee";

//            try
//            {
//                using (var dbConnect = new DBconnect())
//                using (SqlConnection conn = dbConnect.GetOpenConnection())
//                using (SqlCommand cmd = new SqlCommand(query, conn))
//                using (SqlDataReader reader = cmd.ExecuteReader())
//                {
//                    while (reader.Read())
//                    {
//                        EmployeeModel emp = new EmployeeModel
//                        {
//                            Id = reader["Id"].ToString(),
//                            Name = reader["Name"].ToString(),
//                            Email = reader["Email"].ToString(),
//                            Division = reader["Division"].ToString(),
//                            Department = reader["Department"].ToString(),
//                            Location = reader["Location"].ToString(),
//                            Designation = reader["Designation"].ToString(),
//                            Education = reader["Education"].ToString(),
//                            JoinDate = reader["JoinDate"].ToString(),
//                            Status = reader["Status"].ToString()
//                        };

//                        employees.Add(emp);
//                    }
//                }

//                result.ResultSet = employees; // ✅ Add the list to ResultSet

//                if (employees.Count > 0)
//                {
//                    result.StatusCode = 200;
//                    result.Result = "Employees fetched successfully!";
//                }
//                else
//                {
//                    result.StatusCode = 200; // Still 200 OK even if empty
//                    result.Result = "No employees found.";
//                }
//            }
//            catch (Exception ex)
//            {
//                result.StatusCode = 500;
//                result.Result = "Error: " + ex.Message;
//                result.ResultSet = null;
//            }

//            return result;
//        }


//        public Response GetEmployeeById(UserRequestAPI requestAPI)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
