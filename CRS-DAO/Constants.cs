using CRS_MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAO
{
    public static class Constants
    {
        public static string AddAdmin(Admin admin) => $@"INSERT INTO Admin (AdminName, Email, Phone, Address, UserId) 
                                                            VALUES ('{admin.AdminName}', '{admin.Email}', '{admin.Address}', '{admin.Phone}', {admin.UserId})";
        public static string GetLastAdmin() => "SELECT TOP 1 * FROM dbo.Admin ORDER BY 1 DESC";
        public static string GetAllUsers() => "SELECT * FROM dbo.Users";
        public static string GetUser(string username, string password, int roleId) => $"SELECT TOP 1 * FROM dbo.Users WHERE Username = '{username}' AND Password = '{password}' AND RoleId = {roleId}";
        public static string GetUserById(int userId) => $"SELECT * FROM dbo.Users WHERE UserId = {userId}";
        public static string GetLastUser() => $"SELECT TOP 1 * FROM dbo.Users ORDER BY 1 DESC";
    }
}
