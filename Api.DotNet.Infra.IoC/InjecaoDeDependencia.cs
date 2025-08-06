using Api.DotNet.Domain.Repositories;
using Api.DotNet.Infra.Data.Context;
using Api.DotNet.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.DotNet.App.Mappings;
using Api.DotNet.App.Services;
using Api.DotNet.App.Services.Interfaces;

 


namespace Api.DotNet.Infra.IoC
{
    public static class InjecaoDeDependencia
    {
        public static IServiceCollection AddInfraEstrutura(this IServiceCollection servicos, IConfiguration configuracao)
        {
            servicos.AddDbContext<ApplicationDbContext>(opcoes => opcoes.UseNpgsql(configuracao.GetConnectionString("DefaultConnection")));

            servicos.AddScoped<IPersonRepository, PersonRepository>();
            servicos.AddScoped<IProductRepository, ProductRepository>();
            return servicos;
        }

        public static IServiceCollection AddServicos(this IServiceCollection servicos, IConfiguration configuracao)
        {
            object value = servicos.AddAutoMapper(typeof(DomainToDtoMapping));
            servicos.AddScoped<IPersonService, PersonService>();
            servicos.AddScoped<IProductService, ProductService>();
            return servicos;
        }
    }
}
