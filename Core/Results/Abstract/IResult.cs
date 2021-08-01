
namespace Core.Results.Abstract
{
    public interface IResult
    {
        string Message { get; }
        bool Success { get; } 
    }
}
