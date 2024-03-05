using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Pottencial.Teste.Presentation.Api.Controllers
{
    [Route("pottencial-teste/API/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly int MAX_RECORDS = 100;

        protected readonly IMapper _mapper;
        protected BaseController(IMapper mapper) => _mapper = mapper;

    }
}
