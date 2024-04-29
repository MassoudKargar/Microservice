var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepSampleDbContext>(c => c.UseSqlServer("Server=.; Initial Catalog=Microservice_Repo; User Id=masoud; Password=M@$$0ud1001;Encrypt=False;Trust Server Certificate=False;"));
builder.Services.AddScoped<IRepositorySampleDomainUnitOfWork, EfRepositorySampleDomainUnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, EfCategoriesRepository>();
builder.Services.AddScoped<IProductRepository, EfProductsRepository>();
builder.Services.AddScoped<CreateCategoryHandler>();
builder.Services.AddScoped<CreateCategoryHandler>();
builder.Services.AddScoped<AddDiscountHandler>();
builder.Services.AddScoped<CreateProductHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
