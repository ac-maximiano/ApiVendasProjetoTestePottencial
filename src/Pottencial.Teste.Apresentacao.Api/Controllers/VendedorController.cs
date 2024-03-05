using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.Application.Services;
using Pottencial.Teste.Presentation.Api.ViewModels;

namespace Pottencial.Teste.Presentation.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class VendedorController : BaseController
    {
        private readonly IVendedorService _vendedorService;

        public VendedorController(IMapper mapper, IVendedorService vendedorService) : base(mapper)
            => _vendedorService = vendedorService;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProdutoVM>>> Get(int take = 1, int skip = 0)
        {
            if (take < 0 || skip < 0) return BadRequest("O parâmetros fora dos limites permitidos.");
            if (take > MAX_RECORDS) BadRequest($"O parâmetro 'Take' não pode exceder {MAX_RECORDS} registros.");

            try
            {
                var result = await _vendedorService.BuscarAsync(take, skip);

                return Ok(_mapper.Map<IEnumerable<VendedorVM>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }

    }
}
