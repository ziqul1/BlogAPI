using BlogAPI.Models.DTOs.PostDTO;

namespace BlogAPI.Models.DTOs.AuthorDTO
{
    public class GetSingleAuthorDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<GetSinglePostDTO> AuthorMTMPosts { get; set; }
    }
}
