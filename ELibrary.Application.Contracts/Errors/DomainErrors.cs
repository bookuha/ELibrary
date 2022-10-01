using ELibrary.Application.Contracts.Common;

namespace ELibrary.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Book
        {
            public static readonly Error NotFound = new(
                "Author.NotFound",
                "The specified author was not found",
                ErrorTypes.NotFound
            );
        }
    }
}