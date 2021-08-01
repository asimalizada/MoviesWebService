using Core.Results.Abstract;

namespace Core.Results.Concrete
{
    public class Result : IResult
    {
        public string Message { get; }
        public bool Success { get; }

        public Result(bool success, string message) : this(success)
        {
            this.Message = message;
        }

        public Result(bool success)
        {
            this.Success = success;
        }
    }
}
