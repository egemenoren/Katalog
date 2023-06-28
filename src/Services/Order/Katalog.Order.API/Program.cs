using Katalog.Order.Infrastructure;
using Katalog.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var requireAuthorize = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
Katalog.Shared.Helper.IdentityServerRegistry.ConfigureBaseServices(builder.Services, "resource_order", builder.Configuration["IdentityServerURL"]);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
    {
        configure.MigrationsAssembly("Katalog.Order.Infrastructure");
    });
});
builder.Services.AddMediatR(typeof(Katalog.Order.Application.CQRS.Handlers.GetOrdersByUserIdAndStatusQueryHandler).Assembly);
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();
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
