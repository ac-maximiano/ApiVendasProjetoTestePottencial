using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pottencial.Teste.Application.DTOs;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.Presentation.Api.ViewModels;

namespace Pottencial.Teste.Presentation.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IMapper mapper, IProdutoService produtoService) : base(mapper)
            => _produtoService = produtoService;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Post([FromBody] ProdutoVM produto)
        {
            if (produto == null) return BadRequest(ErrorFactory.InvalidData());

            if (ModelState.IsValid)
            {
                try
                {
                    var produtoDto = _mapper.Map<ProdutoDto>(produto);
                    var result = await _produtoService.AdicionarAsync(produtoDto);

                    return new CreatedAtRouteResult("ConsultarProduto", new { id = result }, null);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ErrorFactory.InternalServerError(ex));
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("{id:Guid}", Name = "ConsultarProduto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProdutoVM>> Get(Guid id)
        {
            try
            {
                var produtoDto = await _produtoService.BuscarPorIdAsync(id);

                if (produtoDto == null) return NotFound("Produto não encontrado");

                return Ok(_mapper.Map<ProdutoVM>(produtoDto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }

        }

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
                var result = await _produtoService.BuscarAsync(take, skip);
                
                return Ok(_mapper.Map<IEnumerable<ProdutoVM>>(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }

        [HttpPut("AlterarProduto/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoVM produto)
        {
            if (id != produto.Id) return BadRequest("Os dados informados não são válidos");
            if (produto == null) return BadRequest("Os dados informados não são válidos");

            try
            {
                var produtoEntidade = _mapper.Map<ProdutoDto>(produto);

                await _produtoService.AtualizarAsync(produtoEntidade);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }

        [HttpDelete("ExcluirProduto/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var produtoDto = await _produtoService.BuscarPorIdAsync(id);

                if (produtoDto == null) return NotFound();
                await _produtoService.RemoverAsync(id);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ErrorFactory.InternalServerError(ex));
            }
        }
    }
}
