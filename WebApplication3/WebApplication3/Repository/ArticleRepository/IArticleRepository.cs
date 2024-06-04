using cursach_3.DTO.Article;

namespace cursach_3.Repository.ArticleRepository
{
    public interface IArticleRepository
    {
        ArticleDTO Get(long Article_ID); // Описание метода для получение одной книги из БД
        List<ArticleDTO> GetArticlies(); // Описание метода для получение всех книг из БД
        void Insert(CreateArticle dto); // Описание метода вставки новой книги в БД
        void Update(UpdateArticle dto); // Описание метода обновления информации о книге в БД
        void Delete(long Article_ID);  // Описание метода удаления книги по указанному ID
        void SaveChanges();
    }
}
