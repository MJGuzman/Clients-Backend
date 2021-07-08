using AutoMapper;
using ClientMaster.Api.Framework.MappingProfile;
using ClientMaster.Core.Persistence;
using ClientMaster.Core.Persistence.Seed;
using ClientMaster.Core.Services;
using ClientMaster.Core.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace ClientMaster.Api
{
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClientMaster.Api", Version = "v1" });
            });

            // connection slqServer
            services.AddDbContext<ClientMasterContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    migration => migration.MigrationsAssembly("ClientMaster.Core"));
            });

            //services.AddControllers()
            //    .AddNewtonsoftJson(opt =>
            //    {
            //        opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    });

            services.AddCors(options => options.AddPolicy("corsPolicy", builder =>
            {
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
            }));

            // Automapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ClientMappingProfile());

            });
            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            //Dependency injection
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IMunicipalityService, MunicipalityService>();
            services.AddTransient<ISectorService, SectorService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ClientMasterContext context)
        {
            if (env.IsDevelopment())
            {
                app.EnsureDatabaseIsSeeded(context);
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClientMaster.Api v1"));
            }

            app.UseCors("corsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
