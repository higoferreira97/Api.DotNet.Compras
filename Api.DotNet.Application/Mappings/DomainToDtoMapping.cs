

using Api.DotNet.Application.DTOs;
using Api.DotNet.Domain.Entities;
using AutoMapper;

namespace Api.DotNet.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
        }
    }
}
