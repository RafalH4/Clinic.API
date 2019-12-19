using Clinic.API.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Clinic.API.IRepositories;
using Clinic.API.Repositories;
using Clinic.API.IServices;
using Clinic.API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Clinic.API.Helpers;

namespace Clinic.API
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
            var dbConnection = @"Server=(localdb)\mssqllocaldb;Database=Clinic2;Trusted_Connection=True";
            services.AddDbContext<DataContext>(opt =>
               opt.UseSqlServer(dbConnection));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            services.AddAuthorization(x => x.AddPolicy("RootRole", x => x.RequireRole("root")));
            services.AddAuthorization(x => x.AddPolicy("DoctorRole", x => x.RequireRole("doctor", "root")));
            services.AddAuthorization(x => x.AddPolicy("NurseRole", x => x.RequireRole("nurse", "doctor", "root")));
            services.AddAuthorization(x => x.AddPolicy("PatientRole", x => x.RequireRole("patient", "nurse", "doctor", "root")));

            services.AddControllers();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IMedAreaRepository, MedAreaRepository>();
            services.AddScoped<IMedOfficeRepository, MedOfficeRepository>();
            services.AddScoped<INurseRepository, NurseRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPrescriptionRepository, PrescriptionRepository>();
            services.AddScoped<IReferralRepository, ReferralRepository>();
            services.AddScoped<IRootRepository, RootRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<INurseService, NurseService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IRootService, RootService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IMedOfficeService, MedOfficeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IPrescriptionService, PrescriptionService>();
            services.AddScoped<IReferralService, ReferralService>();

            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddCors();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder => {
                    builder.Run(async context => {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if(error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });
            }

            app.UseCors(x => x.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
