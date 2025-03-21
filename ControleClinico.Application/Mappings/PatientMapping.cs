﻿using AutoMapper;
using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;
using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Mappings
{
    public class PatientMapping : Profile
    {
        public PatientMapping()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<RegisterRequest, User>();
            CreateMap<PatientRequest, Patient>();
            CreateMap<Patient, PatientResponse>();
            CreateMap<DoctorRequest, Doctor>();
            CreateMap<Doctor, DoctorResponse>();
            CreateMap<ConsultationRequest, Consultation>();
            CreateMap<Consultation, ConsultationResponse>();
        }
    }
}