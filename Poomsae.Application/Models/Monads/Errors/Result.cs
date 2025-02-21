namespace Poomsae.Application.Models.Monads.Errors
{
    public class Result<T> : Result where T : class
    {
        public T? Value = null;

        public static Result<T> Success(T _result)
        {
            return new Result<T>() { IsFailure = false, Value = _result };
        }

        public new static Result<T> Failure(string key, string errorPair)
        {
            Result<T> t = new Result<T>();
            t.IsFailure = true;
            t.Errors.Add(key, errorPair);
            return t;
        }
    }

    public class Result
    {
        public bool IsFailure { get; set; }
        public Dictionary<string, string> Errors = new Dictionary<string, string>();

        public static Result Failure(string key, string errorPair)
        {
            Result t = new Result();
            t.IsFailure = true;
            t.Errors.Add(key, errorPair);
            return t;
        }

        public static Result Success()
        {
            Result t = new Result();
            t.IsFailure = false;
            return t;
        }
    }
}