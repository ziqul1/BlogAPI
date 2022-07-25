namespace BlogAPI.Models.DTOs.PostDTO
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }

        // tutaj moze byc chujnia z ta nazwa AuthorIds, sprawdzic czy mi sie nie wyjebie
        // jak bede robił service obsługujący posty
        public List<int> AuthorIds { get; set; }
    }
}
