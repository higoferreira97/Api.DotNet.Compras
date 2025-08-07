using Api.DotNet.App.DTOs;

namespace Api.DotNet.App.Services.Interfaces
{
    public interface IProductService
    { 
        Task<ResultService<ProductDTO>> CreatAsync(ProductDTO productDTO);
        Task<ResultService<ProductDTO>> GetByIdAsync(int id);
        Task<ResultService<ICollection<ProductDTO>>> GetAsync();
        Task<ResultService> UpdateAsync(ProductDTO productDTO);
        Task<ResultService> RemoveAsync(int id);
    }
}
