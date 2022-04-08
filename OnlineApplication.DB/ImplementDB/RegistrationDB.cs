
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlineApplication.Common.Entities;
using OnlineApplication.Common.EnumHelper;
using OnlineApplication.Common.Model;
using OnlineApplication.DB.InterfaceDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApplication.DB.ImplementDB
{
    public class RegistrationDB : IRegistrationDB
    {
        public IConfiguration Configuration { get; }
        public string connectionString;
        private readonly ILogger<RegistrationDB> _logger;
        public RegistrationDB(IConfiguration configuration, ILogger<RegistrationDB> logger)
        {
            this.Configuration = configuration;
            connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _logger = logger;
        }
        public long Add(RegistrationModel registrationModel)
        {
            //var selectedTechnicalParameters = registrationModel.CheckBoxTechnicalParameters.Where(x => x.IsSelected == true).ToList<EnumModel>();
            //var selectedgh = string.Join(",", selectedTechnicalParameters.Select(x => x.TechnicalParameters)).ToList();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var json = JsonConvert.SerializeObject(registrationModel.CheckBoxTechnicalParameters);
                    SqlCommand cmd = new SqlCommand("[dbo].[sp_Registration_Insert]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.AddWithValue("@Name", registrationModel.Name);
                    cmd.Parameters.AddWithValue("@Capacity", registrationModel.Capacity);
                    cmd.Parameters.AddWithValue("@Company", registrationModel.Company);
                    cmd.Parameters.AddWithValue("@Designation", registrationModel.Designation);
                    cmd.Parameters.AddWithValue("@ContactNumber", registrationModel.ContactNumber);
                    cmd.Parameters.AddWithValue("@Category", registrationModel.Category);
                    cmd.Parameters.AddWithValue("@EngagementWithPilot", registrationModel.EngagementWithPilot);
                    cmd.Parameters.AddWithValue("@EmailId", registrationModel.EmailId);
                    cmd.Parameters.AddWithValue("@PdfUrl", registrationModel.RegisterPDFUrl);
                    cmd.Parameters.AddWithValue("@TechnicalParameters",json);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error at AddRegistration() :(");
                //throw;
            }

            //return (long)TaskStatus.Created;
            return (long)Status.IsSuccess;
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public List<RegistrationModel> GetAll()
        {
            List<RegistrationModel> registrationModels = new List<RegistrationModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[sp_Select_tbl_Registration]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        RegistrationModel registrationModel = new RegistrationModel();
                        registrationModel.Id = Convert.ToInt32(rdr["Id"]);
                        registrationModel.Name = rdr["Name"].ToString();
                        registrationModel.EmailId = rdr["EmailId"].ToString();
                        registrationModel.Designation = rdr["Designation"].ToString();
                        registrationModel.ContactNumber = rdr["ContactNumber"].ToString();
                        registrationModel.Company = rdr["Company"].ToString();
                        registrationModel.Capacity = (Common.EnumHelper.Capacity)Convert.ToInt32(rdr["Capacity"]);
                        registrationModel.Category = (Common.EnumHelper.CategoryOptions)Convert.ToInt32(rdr["Category"]);
                        registrationModel.EngagementWithPilot = (Common.EnumHelper.EngagementWithPiolt)Convert.ToInt32(rdr["EngagementWithPilot"]);
                        registrationModels.Add(registrationModel);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error at GetAllRegistration() :(");
                //throw;

            }

            return registrationModels;
        }

        public RegistrationModel GetBy(long Id)
        {
            //try
            //{
            //    RegistrationModel registrationModel = new RegistrationModel();
            //    using (SqlConnection con = new SqlConnection(connectionString))
            //    {
            //        try
            //        {
            //            SqlCommand cmd = new SqlCommand("[dbo].[sp_Registration_ByGetCapacity;]", con);
            //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //            con.Open();
            //            cmd.Parameters.AddWithValue("id", Id);
            //            SqlDataReader rdr = cmd.ExecuteReader();
            //            while (rdr.Read())
            //            {

            //                registrationModel.Id = Convert.ToInt32(rdr["Id"]);
            //                registrationModel.Name = rdr["Name"].ToString();
            //                registrationModel.EmailId = rdr["EmailId"].ToString();
            //                registrationModel.Designation = rdr["Designation"].ToString();
            //                registrationModel.ContactNumber = rdr["ContactNumber"].ToString();
            //                registrationModel.Company = rdr["Company"].ToString();
            //                registrationModel.Capacity = (Common.EnumHelper.Capacity)Convert.ToInt32(rdr["Capacity"]);
            //                registrationModel.Category = (Common.EnumHelper.CategoryOptions)Convert.ToInt32(rdr["Category"]);
            //                registrationModel.EngagementWithPilot = (Common.EnumHelper.EngagementWithPiolt)Convert.ToInt32(rdr["EngagementWithPilot"]);
            //            }
            //            con.Close();

            //        }
            //        catch (Exception ex)
            //        {
            //            _logger.LogError(ex, "Error in GetRegisterDB():(");

            //            throw;
            //        }
            //    }

            //    return registrationModel;
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

            throw new NotImplementedException();
        }

        public long Update(RegistrationModel Obj)
        {
            throw new NotImplementedException();
        }

        public List<RegistrationModel> GetByCategory(int id)
        {
            List<RegistrationModel> registrationModels = new List<RegistrationModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[sp_Registration_ByGetCategory]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        RegistrationModel registrationModel = new RegistrationModel();
                        registrationModel.Id = Convert.ToInt32(rdr["Id"]);
                        registrationModel.Name = rdr["Name"].ToString();
                        registrationModel.EmailId = rdr["EmailId"].ToString();
                        registrationModel.Designation = rdr["Designation"].ToString();
                        registrationModel.ContactNumber = rdr["ContactNumber"].ToString();
                        registrationModel.Company = rdr["Company"].ToString();
                        registrationModel.Category = (Common.EnumHelper.CategoryOptions)Convert.ToInt32(rdr["Category"]);
                        registrationModel.EngagementWithPilot = (Common.EnumHelper.EngagementWithPiolt)Convert.ToInt32(rdr["EngagementWithPilot"]);

                        registrationModels.Add(registrationModel);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error at GetAllRegistrationByCategory() :(");
                //throw;

            }

            return registrationModels;
        }

        public List<RegistrationModel> GetByCapacity(int id)
        {
            List<RegistrationModel> registrationModels = new List<RegistrationModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[sp_Registration_ByGetCapacity]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);
                    connection.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        RegistrationModel registrationModel = new RegistrationModel();
                        registrationModel.Id = Convert.ToInt32(rdr["Id"]);
                        registrationModel.Name = rdr["Name"].ToString();
                        registrationModel.EmailId = rdr["EmailId"].ToString();
                        registrationModel.Designation = rdr["Designation"].ToString();
                        registrationModel.ContactNumber = rdr["ContactNumber"].ToString();
                        registrationModel.Company = rdr["Company"].ToString();
                        registrationModel.Category = (Common.EnumHelper.CategoryOptions)Convert.ToInt32(rdr["Category"]);
                        registrationModel.EngagementWithPilot = (Common.EnumHelper.EngagementWithPiolt)Convert.ToInt32(rdr["EngagementWithPilot"]);
                        registrationModels.Add(registrationModel);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error at GetAllRegistrationByCapacity() :(");
                //throw;

            }

            return registrationModels;
        }

        public List<RegistrationModel> GetByTechnicalParameters(int id)
        {
            List<EnumModel> enumModels = new List<EnumModel>();
            List<RegistrationModel> registrationModels = new List<RegistrationModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("[dbo].[sp_RegistrationByTechnicalParameters]", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", id);

                    connection.Open();


                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        RegistrationModel registrationModel = new RegistrationModel();
                        registrationModel.Id = Convert.ToInt32(rdr["Id"]);
                        registrationModel.Name = rdr["Name"].ToString();
                        registrationModel.EmailId = rdr["EmailId"].ToString();
                        registrationModel.Designation = rdr["Designation"].ToString();
                        registrationModel.ContactNumber = rdr["ContactNumber"].ToString();
                        registrationModel.Company = rdr["Company"].ToString();
                        registrationModel.Category = (Common.EnumHelper.CategoryOptions)Convert.ToInt32(rdr["Category"]);
                        registrationModel.EngagementWithPilot = (Common.EnumHelper.EngagementWithPiolt)Convert.ToInt32(rdr["EngagementWithPilot"]);
                        registrationModels.Add(registrationModel);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error at GetAllRegistrationByTechnicalParameteres() :(");
                //throw;

            }



            return registrationModels;
        }

        public List<EnumModel> TechnicalParameters()
        {
            throw new NotImplementedException();
        }

        //public List<EnumModel> TechnicalParameters()
        //{
        //    List<EnumModel> enumModels = new List<EnumModel>();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            SqlCommand cmd = new SqlCommand("[dbo].[sp_GetTechnicalParameters]", connection);
        //            cmd.CommandType = System.Data.CommandType.StoredProcedure;
        //            connection.Open();
        //            SqlDataReader rdr = cmd.ExecuteReader();
        //            while (rdr.Read())
        //            {
        //                EnumModel enumModel = new EnumModel();
        //                enumModel.Id = Convert.ToInt32(rdr["Id"]);
        //                enumModel.TechnicalParameters = rdr["Item"].ToString();

        //                enumModels.Add(enumModel);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error at GetAllRegistration() :(");
        //        //throw;

        //    }

        //    return enumModels;
        //}
    }
}
