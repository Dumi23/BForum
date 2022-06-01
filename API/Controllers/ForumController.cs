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
            return await Mediator.Send(new PostList.Query());
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

        [HttpPost]
        public async Task<IActionResult> CreateForum(Forum forum)
        {
            return Ok(await Mediator.Send(new ForumCreate.Command {Forum = forum}));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            return Ok(await Mediator.Send(new PostCreate.Command {Post = post}));
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostReply(PostReply postReply)
        {
            return Ok(await Mediator.Send(new PostReplyCreate.Command{Post = post}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditForum(int id, Forum forum)
        {
            forum.Id = id;
            return Ok(await Mediator.Send(new ForumEdit.Command{Forum = forum}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPost(int id, Post post)
        {
            post.Id = id;
            return Ok(await Mediator.Send(new PostEdit.Command{Post = post}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPostReply(int id, PostReply postReply)
        {
            postReply.Id = id;
            return Ok(await Mediator.Send(new PostReplyEdit.Command{PostReply = postReply}));
        }

        
    }
}   