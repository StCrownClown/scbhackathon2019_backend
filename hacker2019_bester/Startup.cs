using hacker2019_bester.Configurations;
using hacker2019_bester.Data;
using hacker2019_bester.Handler;
using hacker2019_bester.Repository;
using hacker2019_bester.Repository.HealthCheck;
using hacker2019_bester.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace hacker2019_bester
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static string _sqlConnectionString;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _sqlConnectionString = Configuration.GetConnectionString("postgres");

            services.AddDbContext<Context>(option =>
            {
                option.UseNpgsql(_sqlConnectionString);
            });

            {
                services.AddScoped<IHealthCheckRepository, HealthCheckRepository>();
                services.AddScoped<IAuthenticationService, AuthenticationService>();
                services.AddScoped<ICustomerService, CustomerService>();
                services.AddScoped<IPaymentService, PaymentService>();
                services.AddScoped<ILoanCalculatorService, LoanCalculatorService>();
                services.AddScoped<IElasticSearch, ElasticSearch>(); 
            }

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .AllowCredentials();
            }));

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            });

            services.Configure<SCBApplication>(Configuration.GetSection("SCBApplication"));
            services.Configure<AWSConfiguration>(Configuration.GetSection("AWSConfiguration"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseCors("MyPolicy");
            app.UseMvc();
        }
    }
}
