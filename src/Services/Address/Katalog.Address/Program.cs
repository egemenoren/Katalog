using Autofac;
using Autofac.Extensions.DependencyInjection;
using Katalog.Address.DependencyResolvers.Autofac;
using Katalog.Address;
using Katalog.Address.Settings;
using Microsoft.Extensions.Options;
using Katalog.Shared.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacAddressServiceModule());
    });

builder.Services.AddSwaggerGen();
builder.Services.Configure<AddressDatabaseSettings>(builder.Configuration.GetSection(nameof(AddressDatabaseSettings)));
builder.Services.AddSingleton<IAddressDatabaseSettings>(sp => sp.GetRequiredService<IOptions<AddressDatabaseSettings>>().Value);
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
