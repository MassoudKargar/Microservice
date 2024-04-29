var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepSampleCommandDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("localConnection")));
builder.Services.AddDbContext<RepSampleQueryDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("localConnection")));
builder.Services.AddScoped<IRepositorySampleDomainUnitOfWork, EfRepositorySampleDomainUnitOfWork>();
builder.Services.AddScoped<ICategoryCommandRepository, EfCommandCategoriesRepository>();
builder.Services.AddScoped<IProductCommandRepository, EfCommandProductsRepository>();
builder.Services.AddScoped<CreateCategoryHandler>();
builder.Services.AddScoped<CreateCategoryHandler>();
builder.Services.AddScoped<AddDiscountHandler>();
builder.Services.AddScoped<CreateProductHandler>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
