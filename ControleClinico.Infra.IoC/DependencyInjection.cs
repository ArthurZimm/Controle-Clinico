﻿using ControleClinico.Application.Contracts.Persistence;
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
            //-------------------DbContext-------------------
            services.AddDbContext<ClinicalDbContext>(options =>
                           options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //-------------------Repositories-------------------
            services.AddScoped<IDoctorRepository,DoctorRepository>();
            services.AddScoped<IPatientRepository,PatientRepository>();
            services.AddScoped<IConsultationRepository,ConsultationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //-------------------Services-------------------
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IConsultationService, ConsultationService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            //-------------------AutoMapper-------------------
            services.AddAutoMapper(typeof(PatientMapping));


            return services;
        }

    }
}