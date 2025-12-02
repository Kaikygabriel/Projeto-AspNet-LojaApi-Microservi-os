using Microsoft.Data.SqlClient;
using Shop.Discont.Infra.Data.Contracts;

namespace Shop.Discont.Infra.Data;

public class SqlConnectionService : ISqlConnection
{
    private SqlConnection _sqlConnection;
    public SqlConnection CreateSqlConnection()
    {
        if(_sqlConnection is null )
            _sqlConnection =new SqlConnection(
                "Server=localhost,1430;Database=Shop.Discont;User Id=sa;Password=kaiky@2048;TrustServerCertificate=True;");
        return _sqlConnection;
    }
}