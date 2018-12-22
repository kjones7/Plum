using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Plum.Commands;
using Plum.Dtos;
using Plum.Models;
using Plum.Queries;

namespace Plum.Pages.Videos
{
    public class IndexModel : PageModel
    {
        private readonly IMediator _mediator;

        public IndexModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public VideoDto Video { get; set; }
        public IEnumerable<AnnotationDto> Annotations { get; set; }
        public IEnumerable<ReplyDto> Replies { get; set; }
        public Member CurrentMember { get; set; }
        public Role Role { get; set; }
        
        public async Task OnGetAsync(int id)
        {
            Video = await _mediator.Send(new GetVideoById(id));
            CurrentMember = await _mediator.Send(new GetSignedInMember(User, Video.LibraryId));
            Role = await _mediator.Send(new GetRoleForMember(CurrentMember.Id));
            Annotations = await _mediator.Send(new GetAnnotationsByVideoId(id));
            Replies = await _mediator.Send(new GetAnnotationRepliesByVideoId(id));
        }

        public async Task<PartialViewResult> OnPostCreateAnnotation(int videoId, string comment, double timestamp)
        {
            var userDto = await _mediator.Send(new GetSignedInUserDto(User));
            var annotation = await _mediator.Send(new CreateAnnotation(userDto.Id, comment, videoId, timestamp));

            return new PartialViewResult
            {
                ViewName = "_Annotation",
                ViewData = new ViewDataDictionary<AnnotationDto>(ViewData, annotation)
            };
        }
        
        public async Task<PartialViewResult> OnPostCreateReply(int annotationId, string text)
        {
            var userDto = await _mediator.Send(new GetSignedInUserDto(User));
            var reply = await _mediator.Send(new CreateAnnotationReply(userDto.Id, annotationId, text));

            return new PartialViewResult
            {
                ViewName = "_Replies",
                ViewData = new ViewDataDictionary<ReplyDto>(ViewData, reply)
            };
        }
        
        public async Task<ContentResult> OnPostEditAnnotation(int userId, int annotationId, string comment)
        {
            await _mediator.Send(new EditAnnotation(userId, comment, annotationId));
            return Content("{ \"response\": true }", "application/json");
        }
        
        public async Task<ContentResult> OnPostDeleteAnnotation(int userId, int annotationId)
        {
            await _mediator.Send(new DeleteAnnotation(userId, annotationId));
            return Content("{ \"response\": true }", "application/json");
        }
        
        public async Task<ContentResult> OnPostEditReply(int userId, int replyId, string text)
        {
            await _mediator.Send(new EditAnnotationReply(userId, replyId, text));
            return Content("{ \"response\": true }", "application/json");
        }

        public async Task<ContentResult> OnPostDeleteReply(int userId, int replyId)
        {
            await _mediator.Send(new DeleteAnnotationReply(userId, replyId));
            return Content("{ \"response\": true }", "application/json");
        }

        public async Task<JsonResult> OnPostFetchRole(int libraryId)
        {
            var member = await _mediator.Send(new GetSignedInMember(User, libraryId));
            var memberList = new List<int>();
            memberList.Add(member.Id);
            var role = await _mediator.Send(new GetRolesForMembers(memberList));
            
            return new JsonResult(role);
        }
    }
}