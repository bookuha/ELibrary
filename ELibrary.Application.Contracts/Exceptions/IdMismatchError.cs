using System.Net;

namespace ELibrary.Application.Contracts.Exceptions
{
    public readonly record struct IdMismatchError() : IServiceException
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;
        public string ErrorMessage { get; } = "Request object id and specified id do not match";
    }
}