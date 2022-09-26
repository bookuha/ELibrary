using System.Net;

namespace ELibrary.Application.Contracts.Exceptions
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }
        public string ErrorMessage { get; }
    }
}