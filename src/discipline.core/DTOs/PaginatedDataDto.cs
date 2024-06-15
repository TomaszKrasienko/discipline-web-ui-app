namespace discipline.core.DTOs;

public class PaginatedDataDto<T>
{
    public T Data { get; set; }
    public MetaDataDto MetaData { get; set; }
}