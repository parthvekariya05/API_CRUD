using API_DEMO.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace API_DEMO.Data
{
    public class CityRepository
    {
        private IConfiguration _configuration;

        public CityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #region GetAllCities
        public List<CityModel> GetAll()
        {
            var cities = new List<CityModel>();            
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_SelectAll_City";
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cities.Add(new CityModel
                {
                    CityID = Convert.ToInt32(reader["CityID"]),
                    CityName = reader["CityName"].ToString(),                    
                    TalukaName = reader["TalukaName"].ToString(),                    
                    DistrictName = reader["DistrictName"].ToString(),                    
                    StateName = reader["StateName"].ToString(),                  
                    CountryName = reader["CountryName"].ToString(),                    
                    Created = Convert.ToDateTime(reader["CreatedAt"]),
                    Modified = Convert.ToDateTime(reader["ModifiedAt"])
                });
            }
            connection.Close();
            return cities;
        }
        #endregion

        #region GetCityByID
        public List<CityModel> GetByID(int CityID)
        {
            var city = new List<CityModel>();
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_SelectByPk_City";
            command.Parameters.AddWithValue("CityID", CityID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                city.Add(new CityModel
                {
                    CityID = Convert.ToInt32(reader["CityID"]),
                    CityName = reader["CityName"].ToString(),                   
                    TalukaName = reader["TalukaName"].ToString(),                   
                    DistrictName = reader["DistrictName"].ToString(),                    
                    StateName = reader["StateName"].ToString(),                                        
                    CountryName = reader["CountryName"].ToString(),
                    Created = Convert.ToDateTime(reader["CreatedAt"]),
                    Modified = Convert.ToDateTime(reader["ModifiedAt"])
                });
            }
            connection.Close();
            return city;
        }
        #endregion

        #region DeleteByID
        public bool DeleteCity(int CityID)
        {
            bool isDeleted = false;
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Delete_City";
            command.Parameters.AddWithValue("CityID", CityID);
            int rowsAffected = command.ExecuteNonQuery();
            isDeleted = rowsAffected > 0;
            return isDeleted;
        }
        #endregion

        #region InsertCity
        public bool InsertCity([Bind("CityName", "TalukaID", "UserID")] CityInsertUpdate city)
        {
            bool isInserted = false;
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Insert_City";
            command.Parameters.AddWithValue("CityName", city.CityName);
            command.Parameters.AddWithValue("TalukaID", city.TalukaID);            
            int rowsAffected = command.ExecuteNonQuery();
            isInserted = rowsAffected > 0;
            return isInserted;
        }

        #endregion

        #region UpdateCity
        public bool UpdateCity(CityInsertUpdate city)
        {
            bool isUpdate = false;
            string connectionString = _configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Update_City";
            command.Parameters.AddWithValue("CityID", city.CityID);
            command.Parameters.AddWithValue("CityName", city.CityName);
            command.Parameters.AddWithValue("TalukaID", city.TalukaID);          
            int rowsAffected = command.ExecuteNonQuery();
            isUpdate = rowsAffected > 0;
            return isUpdate;
        }
        #endregion
    }
}