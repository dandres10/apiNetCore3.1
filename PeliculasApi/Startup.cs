namespace PeliculasApi
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.IdentityModel.Tokens;
    using NetTopologySuite;
    using NetTopologySuite.Geometries;
    using PeliculasApi.Helpers;
    using PeliculasApi.Servicios;
    using System;
    using System.Text;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<IAlmacenadorArchivos, AlmacenadorArchivosAzure>(); // se puede cambiar AlmacenadorArchivosLocal por el de azure
            services.AddHttpContextAccessor();
            services.AddSingleton<GeometryFactory>(NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326));
            services.AddSingleton(provider =>

                new MapperConfiguration(config =>
                {
                    var geometryFactory = provider.GetRequiredService<GeometryFactory>();
                    config.AddProfile(new AutoMapperProfiles(geometryFactory));
                }).CreateMapper()
            );

            services.AddScoped<PeliculaExisteAttribute>();

            services.AddDbContext<ApplicacionDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"),
                sqlServerOptions => sqlServerOptions.UseNetTopologySuite()));
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<ApplicacionDbContext>()
              .AddDefaultTokenProviders();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                       ClockSkew = TimeSpan.Zero
                   }
               );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}