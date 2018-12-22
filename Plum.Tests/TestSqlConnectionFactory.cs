using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data.Common;
using Plum.Factories;

namespace Plum.Tests
{
    public class TestSqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;

        public TestSqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionStrings:TestConnection"];
        }

        public DbConnection GetSqlConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}