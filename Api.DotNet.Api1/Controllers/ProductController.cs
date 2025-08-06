using Api.DotNet.App.DTOs;
using Api.DotNet.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.DotNet.Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _productService.CreatAsync(productDTO);

            if(result.IsSucess) 
                return Ok(result); 

            return BadRequest(result);
        }
        
    }
}
