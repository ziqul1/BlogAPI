﻿namespace BlogAPI.Models.DTOs.AuthorDTO
{
    public class CreateAuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
    }
}
