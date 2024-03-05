namespace Pottencial.Teste.Presentation.Api.ViewModels
{
    public class ErrorVM
    {
        public ErrorVM() { }
        public ErrorVM(int code, string message, string? details = null)
        {
            Code = code;
            Message = message;
            Details = details;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public string? Details { get; set; }
    }
    public static class ErrorFactory
    {
        public static ErrorVM InvalidData() => new ErrorVM(StatusCodes.Status400BadRequest, "Dados informados inválidos");
        public static ErrorVM InternalServerError() => new ErrorVM(StatusCodes.Status500InternalServerError, "Ocorreu no processamento desta requisição");
        public static ErrorVM InternalServerError(Exception innerException) => new ErrorVM(StatusCodes.Status500InternalServerError, "Ocorreu no processamento desta requisição", innerException.Message);
    }
}
