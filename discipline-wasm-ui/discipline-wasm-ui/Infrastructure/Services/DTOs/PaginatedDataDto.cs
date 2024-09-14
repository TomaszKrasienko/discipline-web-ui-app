namespace discipline_wasm_ui.Infrastructure.Services.DTOs;

public class PaginatedDataDto<T>
{
    public T Data { get; set; }
    public MetaDataDto MetaData { get; set; }
}