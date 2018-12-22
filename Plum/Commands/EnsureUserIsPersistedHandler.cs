﻿using Dapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Plum.Extensions;
using Plum.Factories;

namespace Plum.Commands
{
    public class EnsureUserIsPersistedHandler : IRequestHandler<EnsureUserIsPersisted>
    {
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public EnsureUserIsPersistedHandler(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<Unit> Handle(EnsureUserIsPersisted request, CancellationToken cancellationToken)
        {
            var name = request.User.GetName();
            var nameidentifier = request.User.GetNameIdentifier();

            const string sql = @"
                INSERT INTO plum.users (display_name, google_claim_nameidentifier)
                VALUES (@name, @nameidentifier)
                ON CONFLICT ON CONSTRAINT users_google_claim_nameidentifier_key DO NOTHING";

            using (var cnn = _sqlConnectionFactory.GetSqlConnection())
            {
                await cnn.ExecuteAsync(sql, new { name, nameidentifier });
            }

            return Unit.Value;
        }
    }
}
