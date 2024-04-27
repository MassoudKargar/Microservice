using Ms.RepositorySample.Framework;
using Ms.RepositorySamples.Domain.Common;

namespace Ms.RepositorySamples.DAL.Common;

public class EfRepositorySampleDomainUnitOfWork(RepSampleDbContext dbContext) : BaseEfUnitOfWork<RepSampleDbContext>(dbContext), IRepositorySampleDomainUnitOfWork;