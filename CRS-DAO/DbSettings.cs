using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRS_DAO
{
    public static class DbSettings 
    {
        public static string SQLServerConnectionString = "Server=(LocalDb)\\MSSQLLocalDB; Database=CRS; Integrated Security=True";
        public static string MYSQLConnectionString = "server=localhost; user=root; database=crs; port=3306; password=root";
    }
}
