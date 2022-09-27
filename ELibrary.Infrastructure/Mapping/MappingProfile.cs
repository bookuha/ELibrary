using ELibrary.Application.Contracts.Requests;
using ELibrary.Application.Contracts.Responses;
using ELibrary.Domain.Entities;

namespace ELibrary.Infrastructure.Mapping
{
    public static class MappingProfile
    {
        public static Book ToEntity(this BookRequest request)
        {
            if (request != null)
                return new Book
                {
                    Name = request.Name,
                    Genres = request.Genres,
                    BriefDescription = request.BriefDescription,
                    FullDescription = request.FullDescription,
                    OriginallyPublishedAt = request.OriginallyPublishedAt
                };

            return null;
        }

        public static BookResponse ToResponse(this Book entity)
        {
            if (entity != null)
                return new BookResponse
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Genres = entity.Genres,
                    BriefDescription = entity.BriefDescription,
                    FullDescription = entity.FullDescription,
                    OriginallyPublishedAt = entity.OriginallyPublishedAt,
                    AppPublishedAt = entity.AppPublishedAt,
                    Authors = entity.Authors,
                    Files = entity.DownloadableFiles
                };

            return null;
        }
    }
}