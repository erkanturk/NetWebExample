﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace _19_DapperExample.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnetion() => new SqlConnection(_connectionString);
    }
}
