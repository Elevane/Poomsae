using Poomsae.Server.Web.Utils;
using System.Net;

namespace Poomsae.Server.Web.Utils
{
    public class Envelope<T>
    {
        public Envelope()
        { }

        public T? Result { get; set; }
        public Dictionary<string, string>? Errors { get; set; }

        protected internal Envelope(Dictionary<string, string> errorMessage)
        {
            Errors = errorMessage;
        }

        protected internal Envelope(T result)
        {
            Result = result;
        }
    }
}

public class Envelope : Envelope<string>
{
    public Envelope(Dictionary<string, string> result) : base(result)
    {
    }

    public Envelope(Dictionary<string, string> errorMessage, HttpStatusCode code) : base(errorMessage)
    {
    }

    public static Envelope<T> Error<T>(Dictionary<string, string> errorMessage)
    {
        return new Envelope<T>(errorMessage);
    }

    public static Envelope Error(Dictionary<string, string> errorMessage)
    {
        return new Envelope(errorMessage);
    }

    public static Envelope<T> Ok<T>(T result)
    {
        return new Envelope<T>(result);
    }
}