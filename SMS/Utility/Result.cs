namespace Utility;

public interface IResult
{
    bool IsSuccess { get; set; }
    string[] Errors { get; set; }
}

public interface IResult<T> : IResult
{
    T? Data { get; }
}

public class Result<T> : IResult<T>
{
    public T? Data { get; }
    public bool IsSuccess { get; set; }
    public string[] Errors { get; set; }

    private Result(bool isSuccess, T? data, string[] errors)
    {
        Data = data;
        IsSuccess = isSuccess;
        Errors = errors;
    }


    public static IResult<T> Success() => Success(default);
    public static IResult<T> Success(T? data) => new Result<T>(true, data, Array.Empty<string>());
    public static IResult<T> Fail() => new Result<T>(false, default, Array.Empty<string>());
    public static IResult<T> Fail(params string[] errors) => new Result<T>(false, default, errors);
}