using System.Linq;
using System.Threading.Tasks;
using Plum.Commands;
using Plum.Queries;
using Xunit;

namespace Plum.Tests.Commands
{
    public class EditAnnotationReplyTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;

        public EditAnnotationReplyTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        [ResetDatabase]
        public async Task Should_ReturnRightPhrase_When_UserEditsReply()
        {
            // Create a test user
            var userRequest = new CreateUserWithoutAuth("Wendy");
            var user = await _fixture.SendAsync(userRequest);

            const string title = "The New Cold War";
            const string description = "Dork alert.";
            
            // User creates library
            var createLibraryRequest = new CreateLibrary(user.Id, title, description);
            await _fixture.SendAsync(createLibraryRequest);
            
            // Get libraries just created by user
            var getLibrariesRequest = new GetLibrariesForUser(user.Id);
            var libraries = await _fixture.SendAsync(getLibrariesRequest);
            
            // Get id of the single library
            var libraryDtos = libraries.ToList();
            var libraryId = libraryDtos.ElementAt(0).Id;
            
            // create video
            var vidTitle = "Video title";
            var vidLink = "Link goes here";
            var vidDescription = "Video description";
            
            var createVideoRequest = new CreateVideo(user.Id, libraryId, vidTitle, vidLink, vidDescription);
            await _fixture.SendAsync(createVideoRequest);
            
            // Get video
            var getVideosRequest = new GetVideosOfLibrary(libraryId);
            var videos = await _fixture.SendAsync(getVideosRequest);
            var video = videos.ToList().ElementAt(0);
            
            // Create 1 annotation
            var comment1 = "God you're so stupid!";
            var timestamp1 = 0.46;
            
            var annotationRequest1 = new CreateAnnotation(user.Id, comment1, video.Id, timestamp1);

            await _fixture.SendAsync(annotationRequest1);
            
            // get annotations
            var getAnnotationsRequest = new GetAnnotationsByVideoId(video.Id);
            var results = await _fixture.SendAsync(getAnnotationsRequest);
            var annotation = results.ToList().ElementAt(0);

            // create reply
            var replyText1 = "I have three thousand dollars, cash";
            var new_replyText = "I have $38 and a gold bracelet";
            
            var createReplyRequest1 = new CreateAnnotationReply(user.Id, annotation.Id, replyText1);
            
            await _fixture.SendAsync(createReplyRequest1);

            // get reply
            var getReplyRequest = new GetAnnotationRepliesByVideoId(video.Id);
            var replyResults1 = await _fixture.SendAsync(getReplyRequest);
            var reply = replyResults1.Single();
            
            // edit reply
            var editReplyRequest = new EditAnnotationReply(user.Id, reply.Id, new_replyText);
            await _fixture.SendAsync(editReplyRequest);

            // get replies
            var getRepliesRequest = new GetAnnotationRepliesByVideoId(video.Id);
            var replyResults = await _fixture.SendAsync(getRepliesRequest);
            var replies = replyResults.ToList();
            var reply1 = replies.ElementAt(0);

            // Check that reply got created
            Assert.Single(replies);

            // Check that reply returns right thing
            Assert.Equal(new_replyText, reply1.Text);
        }
    }
}
