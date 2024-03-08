using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Pottencial.Teste.Domain.Validation;
using Pottencial.Teste.DomainService.Services;
using Pottencial.Teste.Infra.Data.Common;

namespace Pottencial.Teste.Presentation.Api.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(ILogger<CustomExceptionFilter> logger) => _logger = logger;

        public void OnException(ExceptionContext context)
        {
            _logger.LogError($"Ocorreu uma exceção: {context.Exception}");

            var response = context.Exception switch
            {
                InvalidRequestDataException _ => new BadRequestObjectResult(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Os dados informados não são válidos",
                    Details = context.Exception.Message

                }),
                NotFoundException _ => new NotFoundObjectResult(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = "Registro não encontrado",
                    Details = context.Exception.Message
                }),
                DomainExceptionValidation _ => new BadRequestObjectResult(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Dados inconsistentes",
                    Details = context.Exception.Message
                }),
                QualificadorException _ => new BadRequestObjectResult(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Dados inconsistentes",
                    Details = context.Exception.Message
                }),
                PersistenceException _ => new BadRequestObjectResult(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Erro ao processar a requisição",
                    Details = context.Exception.Message
                }),
                InvalidOperationException _ => new BadRequestObjectResult(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Erro no estado do modelo",
                    Details = context.Exception.Message
                }),
                _ => new ObjectResult(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Details = context.Exception.Message
                })
            };

            context.Result = response;
            context.ExceptionHandled = true;
        }
    }
}
