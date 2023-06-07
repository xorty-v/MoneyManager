using MoneyManager.Contracts.Enums;

namespace MoneyManager.Domain.Responses;

public class BaseResponse<T> : IBaseResponse<T>
{
    public string Message { get; set; }
    public StatusCode StatusCode { get; set; }
    public T Data { get; set; }
}

public interface IBaseResponse<T>
{
    string Message { get; set; }
    StatusCode StatusCode { get; }
    T Data { get; }
}