﻿using System.Linq;
using System.Threading.Tasks;
using Plum.Commands;
using Plum.Queries;
using Xunit;

namespace Plum.Tests.Queries
{
    public class GetRolesForLibraryTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public GetRolesForLibraryTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ResetDatabase]
        public async Task Should_Get_Roles_For_Library()
        {
            // Create a test user
            var userRequest = new CreateUserWithoutAuth("Alice");
            var user = await _fixture.SendAsync(userRequest);

            const string title = "My Fantastic Library";
            const string roleTitle = "Student";
            const string description = "A suitable description.";

            // User creates library
            var createLibraryRequest = new CreateLibrary(user.Id, title, description);
            await _fixture.SendAsync(createLibraryRequest);

            // Get libraries just created by user
            var getLibrariesRequest = new GetLibrariesForUser(user.Id);
            var libraries = await _fixture.SendAsync(getLibrariesRequest);

            // Make sure there's only one library
            var libraryDtos = libraries.ToList();
            Assert.Single(libraryDtos);

            // Get id of the single library
            var libraryId = libraryDtos.ToList().ElementAt(0).Id;

            // User creates role for that library
            var createRoleRequest = new CreateRole(roleTitle, libraryId);
            await _fixture.SendAsync(createRoleRequest);

            // Retrieve that role
            var getRoleRequest = new GetRolesForLibrary(libraryId);
            var role = await _fixture.SendAsync(getRoleRequest);

            // Check that our role is the only role and that title equals the one returned 
            Assert.Contains(roleTitle, role.Select(r => r.Title));
        }
    }
}