﻿using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Plum.Dtos;
using Plum.Factories;

namespace Plum.Queries
{
    public class GetLibrariesCreatedByUserIdHandler : IRequestHandler<GetLibrariesCreatedByUserId, IEnumerable<LibraryDto>>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetLibrariesCreatedByUserIdHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<LibraryDto>> Handle(GetLibrariesCreatedByUserId request, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT id, title, description, created_by, created_at
                FROM plum.libraries
                WHERE created_by = @UserId";

            using (var cnn = _sqlConnectionFactory.GetSqlConnection())
            {
                return await cnn.QueryAsync<LibraryDto>(sql, new { request.UserId });
            }
        }
    }
}
