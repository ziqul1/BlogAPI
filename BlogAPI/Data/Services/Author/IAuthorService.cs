using BlogAPI.Models;
using BlogAPI.Models.DTOs.AuthorDTO;

namespace BlogAPI.Data.Services.Author
{
    public interface IAuthorService
    {
        public Task<List<GetSingleAuthorDTO>> GetAuthorsAsync();
        public Task<GetSingleAuthorDTO> GetSingleAuthorAsync(int id);
        public Task<long> UpdateAuthorAsync(int id, UpdateAuthorDTO author);
        //public Task<Author> CreateAuthorAsync(Author author);
        //public Task<bool> DeleteAuthorAsync(int id);
    }
}
