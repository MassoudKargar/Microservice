using Microsoft.EntityFrameworkCore;
using Ms.RepositorySample.Framework;
using Ms.RepositorySamples.DAL;
using Ms.RepositorySamples.DAL.Categories;
using Ms.RepositorySamples.DAL.Common;
using Ms.RepositorySamples.DAL.Products;
using Ms.RepositorySamples.Domain.Categories;
using Ms.RepositorySamples.Domain.Common;
using Ms.RepositorySamples.Domain.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<RepSampleDbContext>(c => c.UseSqlServer("Server=.; Initial Catalog=Microservice_Repo; User Id=masoud; Password=M@$$0ud1001;Encrypt=False;Trust Server Certificate=False;"));
builder.Services.AddScoped<IRepositorySampleDomainUnitOfWork, EfRepositorySampleDomainUnitOfWork>();
builder.Services.AddScoped<ICategoryRepository, EfCategoriesRepository>();
builder.Services.AddScoped<IProductRepository, EfProductsRepository>();


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
