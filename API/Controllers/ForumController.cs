using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Forums;

namespace API.Controllers
{
    public class ForumController : BaseAPIController
    {

        [HttpGet]
        public async Task<ActionResult<List<Forum>>> GetForums()
        {
            return await Mediator.Send(new List.Query());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Forum>> GetForum(int id)
        {
            return await Mediator.Send(new ListId.Query{Id = id});
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            return await    (new PostList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            return await Mediator.Send(new PostListId.Query{Id = id});
        }

        [HttpGet]
        public async Task<ActionResult<List<PostReply>>> GetPostReplyies()
        {
            return await Mediator.Send(new PostReplyList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PostReply>> GetPostReply(int id)
        {
            return await Mediator.Send(new PostReplyId.Query{Id = id});
        }
    }
}