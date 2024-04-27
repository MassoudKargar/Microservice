namespace Ms.CQRSSamples.DAL.Common;

public class EfRepositorySampleDomainUnitOfWork(RepSampleDbContext dbContext) : BaseEfUnitOfWork<RepSampleDbContext>(dbContext), IRepositorySampleDomainUnitOfWork;