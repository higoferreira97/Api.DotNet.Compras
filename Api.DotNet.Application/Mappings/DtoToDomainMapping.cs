

using Api.DotNet.Application.DTOs;
using Api.DotNet.Domain.Entities;
using AutoMapper;

namespace Api.DotNet.Application.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
        }
    }
}
 