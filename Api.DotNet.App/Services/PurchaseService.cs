using Api.DotNet.App.DTOs;
using Api.DotNet.App.DTOs.Validations;
using Api.DotNet.App.Services.Interfaces;
using Api.DotNet.Domain.Entities;
using Api.DotNet.Domain.Repositories;
using AutoMapper;
using System.Net.NetworkInformation;

namespace Api.DotNet.App.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _personRepository = personRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var validate = new PurchaseDTOValidation().Validate(purchaseDTO);
            if (!validate.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Problema de validação!", validate);

            var productId = await _productRepository.GetIdByCodErpAsync(purchaseDTO.CodErp);
            var personId = await _personRepository.GetIdByDocumentAsync(purchaseDTO.Document);
            var purchase = new Purchase(productId, personId);

            var data = await _purchaseRepository.CreateAsync(purchase);
            purchaseDTO.Id = data.Id;
            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }

        public override bool Equals(object? obj)
        {
            return obj is PurchaseService service &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, service._mapper);
        }

        public async Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAsync()
        {
            var purchases = await _purchaseRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDTO>>(purchases));
        }

      

        public async Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id)
        {
            var purchases = await _purchaseRepository.GetByIdAsync(id);
            if (purchases == null)
                return ResultService.Fail<PurchaseDetailDTO>("Compra não encontrada");

            return ResultService.Ok(_mapper.Map<PurchaseDetailDTO>(purchases));
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_mapper);    
        }
    }
}
