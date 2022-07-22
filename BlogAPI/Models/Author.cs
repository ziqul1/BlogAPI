﻿namespace BlogAPI.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        // IEnumerable?
        public List<AuthorMTMPost> AuthorMTMPosts { get; set; }
    }
}
