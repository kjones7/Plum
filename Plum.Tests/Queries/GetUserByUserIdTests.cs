﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plum.Commands;
using Plum.Queries;
using Xunit;

namespace Plum.Tests.Queries
{
    public class GetUserByUserIdTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public GetUserByUserIdTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ResetDatabase]
        public async Task It_Gets_User_By_UserId()
        {
            //Create user named Alice
            var request = new CreateUserWithoutAuth("Alice");
            var result = await _fixture.SendAsync(request);

            //Retrieve user by id, should be Alice
            var userId = result.Id;
            var request1 = new GetUserByUserId(userId);
            var result1 = await _fixture.SendAsync(request1);

            Assert.Equal("Alice", result1.DisplayName);
        }
    }
}
