using Microsoft.Extensions.Configuration;
using Ms.EntitiesSample.IdGenerators.Contract;
using Snowflake.Core;

namespace Ms.EntitiesSample.IdGenerators.Snowflakes;
public class SnowflakeIdGenerator : IdGenerator
{
    private readonly IdWorker _idWorker;
    public SnowflakeIdGenerator(IConfiguration configuration)
    {
        int datacenterId = int.Parse(configuration["datacenterId"]);
        _idWorker = new IdWorker(datacenterId, 1);

    }

    public long Next()
    {
        return _idWorker.NextId();
    }
}
