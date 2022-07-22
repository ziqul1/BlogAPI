﻿namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        // IEnumerable
        public List<AuthorMTMPost> AuthorMTMPosts { get; set; }
    }
}
