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
    }
}
