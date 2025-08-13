using Api.DotNet.App.DTOs;

namespace Api.DotNet.App.Services.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO);
        Task<ResultService<PurchaseDetailDTO>> GetByIdAsync (int id);
        Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync();
    }
}
