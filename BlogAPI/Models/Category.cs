﻿namespace BlogAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public ICollection<Post> PostCollection {  get; set; }
    }
}
    