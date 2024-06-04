using cursach_3.DTO.Commentary;

namespace cursach_3.Repository.CommentaryRepository
{
    public interface ICommentaryRepository
    {
        CommentaryDTO Get(long Commentary_ID); // Описание метода для получение одной книги из БД
        List<CommentaryDTO> GetCommentaries(); // Описание метода для получение всех книг из БД
        void Insert(CreateCommentary dto); // Описание метода вставки новой книги в БД
        void Update(UpdateCommentary dto); // Описание метода обновления информации о книге в БД
        void Delete(long Commentary_ID);  // Описание метода удаления книги по указанному ID
        void SaveChanges();
    }
}
