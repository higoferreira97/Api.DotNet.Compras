using Api.DotNet.Domain.Repositories;

namespace Api.DotNet.Domain.FiltersDb
{
    public class PersonFilterDb : PagedBaseRequest
    {
        public string Name { get; set; }
    }
}
