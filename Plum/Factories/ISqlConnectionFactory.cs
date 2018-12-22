using System.Data.Common;

namespace Plum.Factories
{
    public interface ISqlConnectionFactory
    {
        DbConnection GetSqlConnection();
    }
}