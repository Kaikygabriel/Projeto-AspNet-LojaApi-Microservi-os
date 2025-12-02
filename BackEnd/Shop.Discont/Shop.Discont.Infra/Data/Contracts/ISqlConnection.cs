using Microsoft.Data.SqlClient;

namespace Shop.Discont.Infra.Data.Contracts;

public interface ISqlConnection
{
    SqlConnection CreateSqlConnection();
}