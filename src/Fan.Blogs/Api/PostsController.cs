using Fan.Blogs.Api.Models;
using Fan.Blogs.Enums;
using Fan.Blogs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fan.Blogs.Api
{
    [Authorize]
    [EnableCors("CorsPolicy")]
    [Route("api/blog/[controller]")]
    public class PostsController : Controller
    {
        private readonly IBlogService _blogSvc;
        public PostsController(IBlogService blogService)
        {
            _blogSvc = blogService;
        }

        /// <summary>
        /// GET api/blog/posts
        /// </summary>
        /// <param name="status">What kind posts. Default <see cref="EPostStatus.Published"/>.</param>
        /// <param name="page">Which page. Default 1.</param>
        /// <param name="size">Page size. Default 20.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<BlogPostListVM> Get(EPostStatus status = EPostStatus.Published, int page = 1, int size = 20)
        {
            var blogPostList = await _blogSvc.GetPostsAsync(page);
            return new BlogPostListVM(blogPostList);
        }

        /// <summary>
        /// GET api/blog/posts/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<BlogPostVM> Get(int id)
        {
            var blogPost = await _blogSvc.GetPostAsync(id);
            return new BlogPostVM(blogPost);
        }
    }
}
