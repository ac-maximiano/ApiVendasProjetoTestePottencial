using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.DomainService.Services;
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
            if (venda == null) return BadRequest(ErrorFactory.InvalidData());

            if (ModelState.IsValid)
            {
                try
                {
                    var vendaDto = _mapper.Map<VendaDto>(venda);
                    var result = await _vendaService.RegistrarVendaAsync(vendaDto);

                    return new CreatedAtRouteResult("ConsultarVenda", new { id = result }, null);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ErrorFactory.InternalServerError(ex));
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id:Guid}", Name = "ConsultarVenda")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VendaQueryVM>> Get(Guid id)
        {
            try
            {
                var vendaDto = await _vendaService.ConsultarVendaAsync(id);

                if (vendaDto == null) return NotFound("Venda não encontrada");

                return Ok(_mapper.Map<VendaQueryVM>(vendaDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VendaQueryVM>>> Get(int take = 1, int skip = 0)
        {
            if (take < 0 || skip < 0) return BadRequest("O parâmetros fora dos limites permitidos.");
            if (take > MAX_RECORDS) BadRequest("O parâmetro 'Take' não pode exceder 100 registros.");

            try
            {
                var result = await _vendaService.ObterVendasAsync(take, skip);

                return Ok(_mapper.Map<IEnumerable<VendaQueryVM>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }

        [HttpPut("ProgredirStatusVenda/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(Guid id)
        {
            try
            {
                await _vendaService.QualificarVenda(id);

                return NoContent();
            }
            catch (QualificadorException ex)
            {
                return BadRequest(ex.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }

        [HttpPut("CancelarVenda/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> CancelarVenda(Guid id)
        {
            try
            {
                await _vendaService.CancelarVenda(id);

                return NoContent();
            }
            catch (QualificadorException ex)
            {
                return BadRequest(ex.ToString());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }
    }
}
