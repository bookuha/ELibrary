using System.Net;

namespace ELibrary.Application.Contracts.Exceptions
{
    public readonly record struct NotFoundError() : IServiceException
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public string ErrorMessage { get; } = "The record has not been found";
    }
}