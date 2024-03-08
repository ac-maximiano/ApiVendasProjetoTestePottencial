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
            if (produto == null) throw new InvalidRequestDataException();
            if (!ModelState.IsValid) throw new InvalidOperationException();

            var produtoDto = _mapper.Map<ProdutoDto>(produto);
            var result = await _produtoService.AdicionarAsync(produtoDto);

            return new CreatedAtRouteResult("ConsultarProduto", new { id = result }, null);
        }

        [HttpGet("{id:Guid}", Name = "ConsultarProduto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProdutoVM>> Get(Guid id)
        {

            var produtoDto = await _produtoService.BuscarPorIdAsync(id);

            if (produtoDto == null) throw new NotFoundException();

            return Ok(_mapper.Map<ProdutoVM>(produtoDto));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ProdutoVM>>> Get(int take = 1, int skip = 0)
        {
            var result = await _produtoService.BuscarAsync(take, skip);

            return Ok(_mapper.Map<IEnumerable<ProdutoVM>>(result));
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Put(Guid id, [FromBody] ProdutoVM produto)
        {
            if (id != produto.Id) throw new InvalidRequestDataException();
            if (produto == null) throw new InvalidRequestDataException();

            var produtoEntidade = _mapper.Map<ProdutoDto>(produto);

            await _produtoService.AtualizarAsync(produtoEntidade);

            return NoContent();
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Delete(Guid id)
        {
            var produtoDto = await _produtoService.BuscarPorIdAsync(id);

            if (produtoDto == null) throw new NotFoundException();
            await _produtoService.RemoverAsync(id);

            return NoContent();
        }
    }
}
