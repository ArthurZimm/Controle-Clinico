using AutoMapper;
using ControleClinico.Application.DTOs.Request;
using ControleClinico.Application.DTOs.Response;
using ControleClinico.Domain.Entity;

namespace ControleClinico.Application.Mappings
{
    public class PatientMapping : Profile
    {

        public PatientMapping()
        {
            CreateMap<PatientRequest, Patient>();
            CreateMap<Patient, PatientResponse>();
        }
    }
}