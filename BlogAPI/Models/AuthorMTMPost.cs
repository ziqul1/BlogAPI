namespace BlogAPI.Models
{
    public class AuthorMTMPost
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
