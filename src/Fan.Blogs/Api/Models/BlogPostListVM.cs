using Fan.Blogs.Models;
using System.Collections.Generic;

namespace Fan.Blogs.Api.Models
{
    public class BlogPostListVM
    {
        public BlogPostListVM(BlogPostList blogPostList)
        {
            BlogPosts = new List<BlogPostVM>();
            foreach (var blogPost in blogPostList)
            {
                BlogPosts.Add(new BlogPostVM(blogPost));
            }
            PostCount = blogPostList.PostCount;
            PageCount = blogPostList.PageCount;
        }

        public List<BlogPostVM> BlogPosts { get; }

        /// <summary>
        /// Total number of posts returned for a <see cref="PostListQuery"/>
        /// </summary>
        public int PostCount { get; }
        /// <summary>
        /// Total number of pages based on <see cref="PostCount"/>.
        /// </summary>
        public int PageCount { get; }

    }
}
