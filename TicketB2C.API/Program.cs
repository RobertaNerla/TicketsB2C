using TicketB2C.API.Mappings;
using TicketB2C.API.Repositories;
using TicketB2C.API.Mappings;
using TicketB2C.API.Services;
using Microsoft.AspNetCore.Diagnostics;
using TicketB2C.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITicketService, SimpleTicketService>();
builder.Services.AddScoped<IPurchasedTicketService, SimplePurchasedTicketService>();
builder.Services.AddScoped<IPurchaseOrderService, SimplePurchaseOrderService>();
builder.Services.AddScoped<ITicketRepository, InMemoryTicketRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, InMemoryPurchaseOrderRepository>();
builder.Services.AddScoped<IPurchasedTicketRepository, InMemoryPurchasedTicketRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<TicketB2C.API.Middlewares.ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
