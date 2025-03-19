﻿using System.Data;
using Microsoft.Data.SqlClient;

namespace CodeMasterDev.Core.Infra.DataBase;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}