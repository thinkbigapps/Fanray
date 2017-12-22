using Fan.Blogs.Enums;
using System;

namespace Fan.Blogs.Api.Models
{
    public class BlogPostIM
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Body { get; set; }
        public string Excerpt { get; set; }
        public string CategoryTitle { get; set; }
        public string TagTitles { get; set; }
        public EPostStatus Status { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
    }
}
