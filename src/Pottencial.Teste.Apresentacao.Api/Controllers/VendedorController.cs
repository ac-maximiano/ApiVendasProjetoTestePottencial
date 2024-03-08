using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Teste.Application.Interfaces;
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProdutoVM>>> Get(int take = 1, int skip = 0)
        {
            var result = await _vendedorService.BuscarAsync(take, skip);

            return Ok(_mapper.Map<IEnumerable<VendedorVM>>(result));
        }
    }
}
