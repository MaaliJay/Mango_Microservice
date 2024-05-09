namespace Mango.Services.AuthAPI.Models.DTO
{
    public class ResponseCuponDTO
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
