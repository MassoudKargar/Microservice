using System.Data;
using System.Data.SqlClient;
using Dapper;
using Ms.EntitiesSample.IdGenerators.Contract;

namespace Ms.EntitiesSample.IdGenerators.SqlSequence;
public class SqlSequenceIdGenerator : IdGenerator
{
    private readonly IDbConnection _connection;
    public SqlSequenceIdGenerator()
    {
        _connection = new SqlConnection("Server=.;Initial Catalog=EntitySampleDb;User Id=sa;Password=1qaz!QAZ;");
    }
    public long Next()
    {
        var result = _connection.ExecuteScalar<long>("SELECT NEXT VALUE FOR [dbo].[MyIdSequence]");
        return result;
    }
}
