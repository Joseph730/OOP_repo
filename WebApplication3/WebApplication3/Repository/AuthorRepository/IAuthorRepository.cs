using cursach_3.DTO.Author;
namespace cursach_3.Repository.AuthorRepository
{
    public interface IAuthorRepository
    {
        AuthorDTO Get(long Author_ID); // Описание метода для получение одной книги из БД
        List<AuthorDTO> GetAuthors(); // Описание метода для получение всех книг из БД
        void Insert(CreateAuthor dto); // Описание метода вставки новой книги в БД
        void Update(UpdateAuthor dto); // Описание метода обновления информации о книге в БД
        void Delete(long Author_ID);  // Описание метода удаления книги по указанному ID
        void SaveChanges();  // Описание метода сохранения изменений в БД
    }
}
