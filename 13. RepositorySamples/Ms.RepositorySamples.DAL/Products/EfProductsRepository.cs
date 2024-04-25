using Ms.RepositorySample.Framework;
using Ms.RepositorySamples.Domain.Products;
using Ms.RepositorySamples.Domain.Products.Entities;

namespace Ms.RepositorySamples.DAL.Products;

public class EfProductsRepository(RepSampleDbContext dbContext) : BaseEfRepository<Product, RepSampleDbContext>(dbContext), IProductRepository;