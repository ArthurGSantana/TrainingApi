using System;
using AutoMapper;
using Training.Api.DTOs;
using Training.Api.Entities;

namespace Training.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeResponseDto>();
        CreateMap<EmployeeRequestDto, Employee>();
    }
}
