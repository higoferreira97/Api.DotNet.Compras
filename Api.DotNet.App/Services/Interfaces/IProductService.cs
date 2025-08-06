using Api.DotNet.App.DTOs;

namespace Api.DotNet.App.Services.Interfaces
{
    public interface IProductService
    { 
        Task<ResultService<ProductDTO>>  CreatAsync(ProductDTO productDTO);
    }
}
