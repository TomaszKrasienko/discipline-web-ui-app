namespace discipline.ui.Communication.DTOs;

public class PaginatedDataDto<T>
{
    public T Data { get; set; }
    public MetaDataDto MetaData { get; set; }
}