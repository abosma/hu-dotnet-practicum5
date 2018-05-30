using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace DotNetPracticum5
{
    public static class DatabaseController
    {
        private static string ConnectionString = @"Data Source=C:\Users\atill\source\repos\DotNetPracticum5\DotNetPracticum5\database;
                                    Version=3; FailIfMissing=True; Foreign Keys=True;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString, true);
        }

    }
}
