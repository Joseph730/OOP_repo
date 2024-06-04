using Microsoft.AspNetCore.Builder;

using cursach_3.DTO.Author;  
using cursach_3.Repository.AuthorRepository; 
namespace cursach_3.Service.AuthorService
{
    public class AuthorService(IAuthorRepository AuthorRepository) : IAuthorService
    {
        private IAuthorRepository _authorRepository = AuthorRepository; 

        public AuthorDTO GetAuthor(long Author_ID) 
        {
            return _authorRepository.Get(Author_ID); 
        }

        public List<AuthorDTO> GetAuthors()  
        {
            return _authorRepository.GetAuthors(); 
        }

        public void InsertAuthor(CreateAuthor dto) 
        {
            _authorRepository.Insert(dto);  
        }

        public void UpdateAuthor(UpdateAuthor dto)  
        {
            _authorRepository.Update(dto); 
        }

        public void DeleteAuthor(long Author_ID)  
        {
            _authorRepository.Delete(Author_ID);  
        }
    }
}
