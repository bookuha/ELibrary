using System.Net;
using ELibrary.Application.Contracts.Exceptions;

namespace ELibrary.Application.Contracts.Errors
{
    public record struct NotFoundError() : IServiceException
    {
        public HttpStatusCode StatusCode { get; } = HttpStatusCode.NotFound;
        public string ErrorMessage { get; } = "The record has not been found";
    }
}