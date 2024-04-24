using Microsoft.EntityFrameworkCore;
using Ms.DomainEventsSample.Core.Domain.People.Events;
using Ms.DomainEventsSample.Framework;
using Ms.DomainEventsSamples.Core.ApplicationServices.People;
using Ms.DomainEventsSamples.Core.ApplicationServices.People.EventHandlers;
using Ms.DomainEventsSamples.Infra.Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SampleContext>(c => c.UseSqlServer("Server=.; Initial Catalog=Microservice_PersonDb; User Id=masoud; Password=M@$$0ud1001;Encrypt=False;Trust Server Certificate=False;")); 
builder.Services.AddTransient<PersonService>();
builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
builder.Services.AddTransient<IDomainEventHandler<PersonCreated>, WitePersonCreatedToConsole>();
builder.Services.AddTransient<IDomainEventHandler<PersonCreated>, WitePersonCreatedToFile>();
builder.Services.AddTransient<IDomainEventHandler<FirstNameChanged>, WiteFirstNameChangedToConsole>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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