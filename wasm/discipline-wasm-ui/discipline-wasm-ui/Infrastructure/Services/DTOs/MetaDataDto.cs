namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class MetaDataDto
{
    public int CurrentPage { get; set; } = 1;
    public int TotalPages { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }
    public bool HasPrevious { get; set; }
    public bool HasNext { get; set; }
}