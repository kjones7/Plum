using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Plum.Dtos;
using Plum.Factories;

namespace Plum.Queries
{
    public class GetVideosOfLibraryHandler : IRequestHandler<GetVideosOfLibrary, IEnumerable<VideoDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetVideosOfLibraryHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<VideoDto>> Handle(GetVideosOfLibrary request, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT
                    videos.title,
                    videos.description,
                    videos.id
                FROM plum.videos
                WHERE videos.library_id = @LibraryId
                AND videos.deleted_at IS NULL
                ORDER BY videos.created_at DESC";

            using (var cnn = _sqlConnectionFactory.GetSqlConnection())
            {
                return await cnn.QueryAsync<VideoDto>(sql, new { request.LibraryId });
            }
        }
    }
}