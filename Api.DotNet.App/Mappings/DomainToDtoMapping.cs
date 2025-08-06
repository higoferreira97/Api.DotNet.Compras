

using Api.DotNet.App.DTOs;
using Api.DotNet.Domain.Entities;
using AutoMapper;

namespace Api.DotNet.App.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Product, ProductDTO>();
        }
    }
}
