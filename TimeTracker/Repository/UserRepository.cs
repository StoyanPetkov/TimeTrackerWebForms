using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using TimeTracker.Entity;
using System.Text.RegularExpressions;

namespace TimeTracker.Repository
{
    public class UserRepository
    {
        string connectionString = @"Data Source=STOYAN-PC\SQLEXPRESS;Initial Catalog=TimeTrackerDB;Integrated Security=True";

        public int? CheckForDuplicateUser(string username)
        {
            string SqlCommandCheckForDuplicate = "C_spCheckForDuplicateUser";
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                using (SqlCommand _SqlCommand = new SqlCommand(SqlCommandCheckForDuplicate, dbConnection))
                {
                    _SqlCommand.CommandType = CommandType.StoredProcedure;
                    _SqlCommand.Parameters.Add(new SqlParameter("@UserName", username));
                    int? executeValue = (int?)_SqlCommand.ExecuteScalar();
                    return executeValue;
                }
            }
        }

        public bool ValidatePhoneNumber(string data)
        {
            char[] charsToTrim = { '*', ' ', '\'', '.', '-', ';'};
            data = data.Trim(charsToTrim);
            string PhonePattern = @"08[6-9][6-9]\d{6}";
            string PlusPhonePattern = @"\+3598[6-9][6-9]\d{6}";

            if ((data.Length == 10 || data.Length == 13) && Regex.IsMatch(data, PhonePattern) || Regex.IsMatch(data, PlusPhonePattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Users GetByUserNameAndPassword(string username, string password)
        {
            Users user = new Users();
            string SqlCommandVerifyUser = "G_spGetByUserNameAndPassword";
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();

                using (SqlCommand _SqlCommand = new SqlCommand(SqlCommandVerifyUser, dbConnection))
                {
                    _SqlCommand.CommandType = CommandType.StoredProcedure;
                    _SqlCommand.Parameters.Add(new SqlParameter("@UserName", username));
                    _SqlCommand.Parameters.Add(new SqlParameter("@Password", password));

                    using (SqlDataReader _SqlReader = _SqlCommand.ExecuteReader())
                    {
                        while (_SqlReader.Read())
                        {
                            user.Id = _SqlReader.GetInt32(0);
                            user.FirstName = _SqlReader.GetString(1);
                            user.LastName = _SqlReader.GetString(2);
                            user.Mail = _SqlReader.GetString(3);
                            user.UserName = _SqlReader.GetString(4);
                            user.Password = _SqlReader.GetString(5);
                            user.PhoneNumber = _SqlReader.GetString(6);
                            user.UserRole = _SqlReader.GetInt32(7);
                        }
                    }
                }
            }
            return user;
        }

        public DataTable GetAll()
        {
            string SqlCommandGetUsers = "GA_spAllUser";
            DataTable SqlDataTable = new DataTable();

            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                SqlCommand _SqlCommand = new SqlCommand(SqlCommandGetUsers, dbConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDataAdapter = new SqlDataAdapter();
                SqlDataAdapter.SelectCommand = _SqlCommand;
                SqlDataAdapter.Fill(SqlDataTable);
            }
            return SqlDataTable;
        }

        public void Delete(int id)
        {
            string SqlCommandDelete = "D_spDeleteUser";
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                SqlCommand _SqlCommand = new SqlCommand(SqlCommandDelete, dbConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@Id", id));
                _SqlCommand.ExecuteNonQuery();
            }
        }

        public int Insert(Users user)
        {
            if (CheckForDuplicateUser(user.UserName) == null)
            {
                string SqlCommandInsert = "I_spUser";
                using (SqlConnection dbConnection = new SqlConnection(connectionString))
                {
                    dbConnection.Open();
                    SqlCommand _SqlCommand = new SqlCommand(SqlCommandInsert, dbConnection);
                    _SqlCommand.CommandType = CommandType.StoredProcedure;
                    _SqlCommand.Parameters.Add(new SqlParameter("@FirstName", user.FirstName.Trim()));
                    _SqlCommand.Parameters.Add(new SqlParameter("@LastName", user.LastName.Trim()));
                    _SqlCommand.Parameters.Add(new SqlParameter("@Mail", user.Mail.Trim()));
                    _SqlCommand.Parameters.Add(new SqlParameter("@Password", user.Password.Trim()));
                    _SqlCommand.Parameters.Add(new SqlParameter("@UserName", user.UserName.Trim()));
                    _SqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber.Trim()));
                    _SqlCommand.Parameters.Add(new SqlParameter("@Role", 2));
                    _SqlCommand.ExecuteNonQuery();
                }
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int Update(Users user)
        {
            int rowAffcted = -1;
            string SqlCommandUpdate = "U_spUpdate";
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                SqlCommand _SqlCommand = new SqlCommand(SqlCommandUpdate, dbConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("@Id", user.Id));
                _SqlCommand.Parameters.Add(new SqlParameter("@FirstName", user.FirstName.Trim()));
                _SqlCommand.Parameters.Add(new SqlParameter("@LastName", user.LastName.Trim()));
                _SqlCommand.Parameters.Add(new SqlParameter("@Mail", user.Mail.Trim()));
                //_SqlCommand.Parameters.Add(new SqlParameter("@UserName", user.UserName.Trim()));
                _SqlCommand.Parameters.Add(new SqlParameter("@Password", user.Password.Trim()));
                _SqlCommand.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber.Trim()));
                _SqlCommand.Parameters.Add(new SqlParameter("@Role", user.UserRole));
                rowAffcted = _SqlCommand.ExecuteNonQuery();
            }
            if (rowAffcted > 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //public void UpdateRoles(int role, int id)
        //{
        //    string SqlCommandUpdateRole = "R_spEditRoles";
        //    using (SqlConnection dbConnection = new SqlConnection(connectionString))
        //    {
        //        dbConnection.Open();
        //        SqlCommand _SqlCommand = new SqlCommand(SqlCommandUpdateRole,dbConnection);
        //        _SqlCommand.CommandType = CommandType.StoredProcedure;
        //        _SqlCommand.Parameters.Add(new SqlParameter("@Role",role));
        //        _SqlCommand.Parameters.Add(new SqlParameter("@Id",id));
        //        _SqlCommand.ExecuteNonQuery();
        //    }
        //}

        public int GetUserRole(int id)
        {
            string SqlCommandGetRole = "R_GetRole";
            using (SqlConnection dbConnection = new SqlConnection(connectionString))
            {
                dbConnection.Open();
                SqlCommand _SqlCommand = new SqlCommand(SqlCommandGetRole,dbConnection);
                _SqlCommand.CommandType = CommandType.StoredProcedure;
                _SqlCommand.Parameters.Add(new SqlParameter("Id",id));
                int role = (int)_SqlCommand.ExecuteScalar();
                return role;
            }
        }
    }
}
