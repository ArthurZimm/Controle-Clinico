using ControleClinico.Application.Contracts.Persistence;
using ControleClinico.Application.Contracts.Services;
using ControleClinico.Application.Mappings;
using ControleClinico.Application.Services;
using ControleClinico.Infraestructure.Context;
using ControleClinico.Infraestructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ControleClinico.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ClinicalDbContext>(options =>
                           options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IConsultationService, ConsultationService>();
            services.AddAutoMapper(typeof(PatientMapping));


            return services;
        }

    }
}