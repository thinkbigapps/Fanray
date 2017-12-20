using Fan.Blogs.Models;
using System;

namespace Fan.Blogs.Api.Models
{
    public class BlogPostVM
    {
        public BlogPostVM(BlogPost blogPost)
        {
            Id = blogPost.Id;
            Title = blogPost.Title;
            Author = blogPost.User.DisplayName;
            CreatedOn = blogPost.CreatedOn;
        }

        public int Id { get; set; }
        public string Title { get; }
        public string Author { get; }
        public DateTimeOffset CreatedOn { get; }
    }
}
