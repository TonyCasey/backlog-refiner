using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Comments.Core;
using Comments.Core.DTO;
using Comments.Core.Services;
using Comments.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Comments.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;


        public CommentController(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        // SEARCH: api/Comment
        [HttpGet, Route("Search")]
        [ProducesResponseType(typeof(SearchResponseModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Search(SearchModel model)
        {

            if (ModelState.IsValid)
            {
                InitUserCredentials();
                var results = _mapper.Map( _commentService.Search(model, CompanyGuid), new List<CommentResponseModel>());
                var response = new SearchResponseModel() { Data = results };
                return Ok(response);
            }

            return new NoContentResult();
        }

        // GET: api/Comment/5
        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(CommentResponseModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(Guid guid)
        {
            if (ModelState.IsValid)
            {

                if (guid == Guid.Empty)
                    return new BadRequestResult();

                Comment comment = await _commentService.Get(guid);

                if (comment == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (comment.CompanyGuid != CompanyGuid)
                {
                    return new UnauthorizedResult();
                }

                return Ok(_mapper.Map(comment, new CommentResponseModel()));
            }

            return null;
        }

        // POST: api/Comment
        [HttpPost]
        [ProducesResponseType(typeof(CommentResponseModel), (int) HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Error), (int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] CommentRequestModel model)
        {
            Comment newComment = null;

            if (ModelState.IsValid)
            {
                InitUserCredentials();
                
                newComment = _mapper.Map(model, new Comment
                {
                    Guid = Guid.NewGuid(),
                    UserGuid = UserGuid,
                    CompanyGuid = CompanyGuid,
                    CreationTime = DateTime.UtcNow,
                    CreationUserGuid = UserGuid
                }
                );

                try
                {
                    await _commentService.Save(newComment);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return CreatedAtAction(nameof(Post), _mapper.Map(newComment, new CommentResponseModel()));
        }


        // PUT: api/Comment/5
        [HttpPut("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Put([FromBody] CommentRequestModel model, Guid guid)
        {

            if (ModelState.IsValid)
            {
                if(guid == Guid.Empty)
                    return new BadRequestResult();

                Comment comment = await _commentService.Get(guid);

                if(comment == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (comment.UserGuid != UserGuid)
                {
                    return new UnauthorizedResult();
                }

                var mapped = _mapper.Map(model, comment);
                mapped.LastUpdateUserGuid = UserGuid;
                mapped.LastUpdateTime = DateTime.Now;

                try
                {
                    await _commentService.Save(mapped);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return new OkResult();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{guid}")]
        [ProducesResponseType(typeof(OkResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Error), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(NoContentResult), (int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid guid)
        {

            if (ModelState.IsValid)
            {
                if (guid == Guid.Empty)
                    return new BadRequestResult();

                Comment comment = await _commentService.Get(guid);

                if (comment == null)
                    return new NoContentResult();

                InitUserCredentials();

                if (comment.UserGuid != UserGuid)
                {
                    return new UnauthorizedResult();
                }

                comment.Deleted = true;
                comment.LastUpdateTime = DateTime.Now;
                comment.LastUpdateUserGuid = UserGuid;

                try
                {
                    await _commentService.Save(comment);
                }
                catch (Exception e)
                {
                    Log.Error(e.StackTrace);
                    throw;
                }
            }

            return new OkResult();
        }

    }
}
