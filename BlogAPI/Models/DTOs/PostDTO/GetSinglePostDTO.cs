namespace BlogAPI.Models.DTOs.PostDTO
{
    public class GetSinglePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
