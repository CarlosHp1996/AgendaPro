using System.Net;

namespace AgendaPro.Domain.Helpers
{
    public class Result<T> : Result where T : class
    {
        public Result()
        {
        }

        public Result(T value)
        {
            Value = value;
        }

        public T Value { get; set; }
        public int Count { get; set; }
    }

    public class Result
    {
        public bool HasSuccess { get; protected set; }
        public bool HasError => !HasSuccess;
        public IList<string> Errors { get; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public DateTime DataRequisicao { get; set; }

        public Result()
        {
            HasSuccess = true;
            HttpStatusCode = HttpStatusCode.OK;
            Errors = new List<string>();
            DataRequisicao = DateTime.Now;
        }

        public void WithError(string errorMessage)
        {
            HttpStatusCode = HttpStatusCode.BadRequest;
            HasSuccess = false;
            Errors.Add(errorMessage);
            DataRequisicao = DateTime.Now;
        }

        public void WithUnauthorized(string errorMessage)
        {
            HttpStatusCode = HttpStatusCode.Unauthorized;
            HasSuccess = false;
            Errors.Add(errorMessage);
            DataRequisicao = DateTime.Now;
        }


        public void WithNotFound(string errorMessage)
        {
            HttpStatusCode = HttpStatusCode.NotFound;
            HasSuccess = false;
            Errors.Add(errorMessage);
            DataRequisicao = DateTime.Now;
        }

        public void WithException(string errorMessage)
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
            HasSuccess = false;
            Errors.Add(errorMessage);
            DataRequisicao = DateTime.Now;
        }
    }
}
