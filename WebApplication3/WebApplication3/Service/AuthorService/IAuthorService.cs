
using cursach_3.DTO.Author;

namespace cursach_3.Service.AuthorService
{
    public interface IAuthorService
    {
        AuthorDTO GetAuthor(long Author_ID); 
        List<AuthorDTO> GetAuthors(); 
        void InsertAuthor(CreateAuthor dto);  
        void UpdateAuthor(UpdateAuthor dto);  
        void DeleteAuthor(long Author_ID);
    }
}
