using Katalog.Discount.Repository;
using Katalog.Discount.Services;
using Katalog.Shared.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


var requireAuthorize = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");
Katalog.Shared.Helper.IdentityServerRegistry.ConfigureBaseServices(builder.Services, "resource_discount", builder.Configuration["IdentityServerURL"]);
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.Authority = builder.Configuration["IdentityServerURL"];
//    options.Audience = "resource_discount";
//    options.RequireHttpsMetadata = false;
//});

//builder.Services.AddControllers(opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter(requireAuthorize));
//});
//builder.Services.AddHttpContextAccessor();


builder.Services.AddSingleton<IDiscountRepository, DiscountRepository>();
builder.Services.AddSingleton<IDiscountService, DiscountService>();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();
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

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
