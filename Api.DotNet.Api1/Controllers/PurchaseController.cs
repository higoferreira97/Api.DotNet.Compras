using Api.DotNet.App.DTOs;
using Api.DotNet.App.Services;
using Api.DotNet.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Api.DotNet.Api1.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);

                if (result.IsSucess)
                    return Ok(result);

                return BadRequest(result);
            }

            catch (ValidationException ex)
            {
                var result = ResultService.Fail(ex.Message);
                return BadRequest(result);
            }


        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {

            var result = await _purchaseService.GetAsync();

            if (result.IsSucess)
                return Ok(result);

            return BadRequest(result);



        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {

            var result = await _purchaseService.GetByIdAsync(id);

            if (result.IsSucess)
                return Ok(result);  

            return BadRequest(result);



        }
    }
}
