﻿using Dapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Plum.Dtos;
using Plum.Factories;
using Plum.Models;

namespace Plum.Queries
{
    public class GetRolesForLibraryHandler : IRequestHandler<GetRolesForLibrary, IEnumerable<Role>>
    {
        private readonly IMapper _mapper;
        private readonly ISqlConnectionFactory _sqlConnectionFactory;

        public GetRolesForLibraryHandler(IMapper mapper, ISqlConnectionFactory sqlConnectionFactory)
        {
            _mapper = mapper;
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<Role>> Handle(GetRolesForLibrary request, CancellationToken cancellationToken)
        {
            const string sql = @"
                SELECT rol.id, rol.title, rpv.privilege_alias
                FROM plum.roles rol
                LEFT JOIN plum.role_privileges rpv
                ON rpv.role_id = rol.id
                WHERE
	                library_id = @LibraryId
	                AND rol.deleted_at IS NULL
                ORDER BY rol.created_at";

            using (var cnn = _sqlConnectionFactory.GetSqlConnection())
            {
                var dtos = await cnn.QueryAsync<RoleDto>(sql, request);
                return _mapper.Map<IEnumerable<Role>>(dtos);
            }
        }
    }
}
