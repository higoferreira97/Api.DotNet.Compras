

using Api.DotNet.Application.DTOs;
using Api.DotNet.Domain.Entities;

namespace Api.DotNet.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        Task CreateAsync(Person person);
    }
}
