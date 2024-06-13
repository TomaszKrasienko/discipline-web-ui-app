namespace discipline.core.DTOs;

public class ResponseDto
{
    public bool IsValid { get; }
    public string Message { get; } 

    private ResponseDto(bool isValid, string message = null)
    {
        IsValid = isValid;
        Message = message;
    }

    public static ResponseDto GetValid()
        => new ResponseDto(true);

    public static ResponseDto GetInvalid(string message)
        => new ResponseDto(false, message);

    public static ResponseDto GetInvalid()
        => new ResponseDto(false, "There was an error");
}