﻿using System.Linq;
using System.Threading.Tasks;
using Plum.Commands;
using Plum.Queries;
using Xunit;

namespace Plum.Tests.Commands
{
    public class DeleteRoleByIdTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public DeleteRoleByIdTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ResetDatabase]
        public async Task ItDeletesRoleById()
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

            // Retrieve roles
            var getRoleRequest = new GetRolesForLibrary(libraryId);
            var role = await _fixture.SendAsync(getRoleRequest);

            // Return roles
            var roleDtos = role.ToList();

            // RoleId of role after default (our created role)
            var roleId = roleDtos.ToList().ElementAt(1).Id;

            // Delete that role
            var deleteRoleRequest = new DeleteRoleById(roleId);
            await _fixture.SendAsync(deleteRoleRequest);

            // Retrieve remaining roles
            var getRolesLeftRequest = new GetRolesForLibrary(libraryId);
            var roleLeft = await _fixture.SendAsync(getRolesLeftRequest);

            var roleCount = roleLeft.Count();

            Assert.Equal(1, roleCount);
        }
    }
}
