﻿using System.Threading.Tasks;
using Dapper;
using MediatR;
using System.Threading;
using Plum.Factories;

namespace Plum.Commands
{
    public class UpdateVideoInfoHandler : IRequestHandler<UpdateVideoInfo>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public UpdateVideoInfoHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Unit> Handle(UpdateVideoInfo request, CancellationToken cancellationToken)
        {
            var videoId = request.VideoId;
            var newTitle = request.NewTitle;
            var newDescription = request.NewDescription;

            const string sql = @"
                UPDATE plum.videos
                SET title = @newTitle, description = @newDescription
                WHERE id = @videoId";

            using (var cnn = _sqlConnectionFactory.GetSqlConnection())
            {
                await cnn.QueryAsync(sql, new { videoId, newTitle, newDescription });
            }

            return Unit.Value;
        }
    }
}