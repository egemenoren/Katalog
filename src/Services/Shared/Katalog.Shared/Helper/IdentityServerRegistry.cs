using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Katalog.Shared.Helper
{
    static public class IdentityServerRegistry
    {
        public static void ConfigureBaseServices(this IServiceCollection services,string audience,string identityServerUrl)
        {

            services.AddHttpContextAccessor();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.Authority = identityServerUrl;
                options.Audience = audience;
                options.RequireHttpsMetadata = false;
            });
            services.AddControllers(opt =>
            {
                opt.Filters.Add(new AuthorizeFilter());
            });
        }
    }
}
