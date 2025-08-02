

using Api.DotNet.App.DTOs;
using Api.DotNet.Domain.Entities;

namespace Api.DotNet.App.Services.Interfaces
{
    public interface IPersonService
    {
        Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO);
        //Task CreateAsync(Person person);
    }
}
