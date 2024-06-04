using cursach_3.DTO.Article;
namespace cursach_3.Service.ArticleService
{
    public interface IArticleService
    {
        ArticleDTO GetArticle(long Article_ID); 
        List<ArticleDTO> GetArticlies(); 
        void InsertArticle(CreateArticle dto);  
        void UpdateArticle(UpdateArticle dto);  
        void DeleteArticle(long Article_ID); 
    }
}
