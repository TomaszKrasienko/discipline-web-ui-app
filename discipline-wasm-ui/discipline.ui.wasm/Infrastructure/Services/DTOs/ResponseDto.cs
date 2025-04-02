namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class ResponseDto
{
    public bool IsValid { get; }
    public string Message { get; }
    public object Result { get; set; }

    private ResponseDto(bool isValid, string message = null, object result = null)
    {
        IsValid = isValid;
        Message = message;
        Result = result;
    }

    public static ResponseDto GetValid()
        => new ResponseDto(true);

    public static ResponseDto GetValid(string message)
        => new ResponseDto(true, message);
    
    public static ResponseDto GetValid(object t)
        => new ResponseDto(true, null, t);

    public static ResponseDto GetInvalid(string message)
        => new ResponseDto(false, message);

    public static ResponseDto GetInvalid()
        => new ResponseDto(false, "There was an error");
}