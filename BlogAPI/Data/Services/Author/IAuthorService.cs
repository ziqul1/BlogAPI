using BlogAPI.Models;

namespace BlogAPI.Data.Services.Author
{
    public interface IAuthorService
    {
        public Task<IEnumerable<Models.Author>> GetAuthorsAsync();
        //public Task<Author> GetSingleAuthorAsync(int id);
        //public Task<long> UpdateAuhorAsync(int id, Author author);
        //public Task<Author> CreateAuthorAsync(Author author);
        //public Task<bool> DeleteAuthorAsync(int id);
    }
}
