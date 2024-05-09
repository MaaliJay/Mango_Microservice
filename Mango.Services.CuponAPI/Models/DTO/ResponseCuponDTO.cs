namespace Mango.Services.CuponAPI.Models.DTO
{
    public class ResponseCuponDTO
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "";
    }
}
