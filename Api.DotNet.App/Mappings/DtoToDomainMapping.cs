

using Api.DotNet.App.DTOs;
using Api.DotNet.Domain.Entities;
using AutoMapper;

namespace Api.DotNet.App.Mappings
{
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<PersonDTO, Person>();
            CreateMap<ProductDTO, Product>();
        }
    }
}
