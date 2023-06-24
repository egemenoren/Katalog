using Autofac;
using Autofac.Extensions.DependencyInjection;
using Katalog.Product.DependencyResolvers.Autofac;
using Katalog.Product.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.


Katalog.Shared.Helper.IdentityServerRegistry.ConfigureBaseServices(builder.Services, "resource_product", configuration["IdentityServerURL"]);
//builder.Services.AddControllers(opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter());
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.Authority = configuration["IdentityServerURL"];
//    options.Audience = "resource_product";
//    options.RequireHttpsMetadata = false;
//});

#region Project Dependencies

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacProductServiceModule());
    });

builder.Services.AddAutoMapper(typeof(Program));

#endregion Project Dependencies

#region Configuration Dependencies

builder.Services.Configure<ProductDatabaseSettings>(builder.Configuration.GetSection(nameof(ProductDatabaseSettings)));
builder.Services.AddSingleton<IProductDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value);

#endregion Configuration Dependencies

#region Swagger

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Katalog.Product",
        Version = "v1"
    });
});

#endregion Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Katalog.Product v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();



app.Run();