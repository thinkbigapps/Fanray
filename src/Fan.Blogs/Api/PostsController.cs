using Fan.Blogs.Enums;
using Fan.Blogs.Models;
using Fan.Blogs.Services;
using Fan.Blogs.ViewModels;
using Fan.Settings;
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
        private readonly ISettingService _settingSvc;
        public PostsController(
            IBlogService blogService,
            ISettingService settingService
            )
        {
            _blogSvc = blogService;
            _settingSvc = settingService;
        }

        /// <summary>
        /// GET api/blog/posts
        /// </summary>
        /// <param name="status">What kind posts. Default <see cref="EPostStatus.Published"/>.</param>
        /// <param name="page">Which page. Default 1.</param>
        /// <param name="size">Page size. Default 20.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<BlogPostListViewModel> Get(EPostStatus status = EPostStatus.Published, int page = 1, int size = 20)
        {
            var posts = await _blogSvc.GetPostsAsync(page);
            var blogSettings = await _settingSvc.GetSettingsAsync<BlogSettings>();
            var vm = new BlogPostListViewModel(posts, blogSettings, Request);
            return vm;
        }

        /// <summary>
        /// GET api/blog/posts/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<BlogPostViewModel> Get(int id)
        {
            var blogPost = await _blogSvc.GetPostAsync(id);
            var blogSettings = await _settingSvc.GetSettingsAsync<BlogSettings>();
            var vm = new BlogPostViewModel(blogPost, blogSettings, Request);
            return vm;
        }
    }
}
