using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.Presentation.Api.Filters;
using Pottencial.Teste.Presentation.Api.ViewModels;

namespace Pottencial.Teste.Presentation.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class VendasController : BaseController
    {
        private readonly IVendaService _vendaService;

        public VendasController(IMapper mapper, IVendaService vendaService) : base(mapper)
            => _vendaService = vendaService;

        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] VendaCommandVM venda)
        {
            if (venda == null) throw new InvalidRequestDataException();
            if (!ModelState.IsValid) throw new InvalidOperationException();

            var vendaDto = _mapper.Map<VendaDto>(venda);
            var result = await _vendaService.RegistrarVendaAsync(vendaDto);

            return new CreatedAtRouteResult("ConsultarVenda", new { id = result }, null);
        }

        [HttpGet("{id:Guid}", Name = "ConsultarVenda")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendaQueryVM>> Get(Guid id)
        {
            var vendaDto = await _vendaService.ConsultarVendaAsync(id);

            if (vendaDto == null) throw new NotFoundException();

            return Ok(_mapper.Map<VendaQueryVM>(vendaDto));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VendaQueryVM>>> Get(int take = 1, int skip = 0)
        {
            var result = await _vendaService.ObterVendasAsync(take, skip);

            return Ok(_mapper.Map<IEnumerable<VendaQueryVM>>(result));
        }

        [HttpPut("ProgredirStatusVenda/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(Guid id)
        {
            var venda = await _vendaService.ConsultarVendaAsync(id);

            if (venda == null) throw new NotFoundException();
            await _vendaService.QualificarVenda(id);

            return NoContent();
        }

        [HttpPut("CancelarVenda/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CancelarVenda(Guid id)
        {
            var venda = await _vendaService.ConsultarVendaAsync(id);

            if (venda == null) throw new NotFoundException();
            await _vendaService.CancelarVenda(id);

            return NoContent();
        }
    }
}