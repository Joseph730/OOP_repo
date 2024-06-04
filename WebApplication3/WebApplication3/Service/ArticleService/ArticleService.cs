using Microsoft.AspNetCore.Builder;

using cursach_3.DTO.Article;  
using cursach_3.Repository.ArticleRepository; 
namespace cursach_3.Service.ArticleService
{
    public class ArticleService(IArticleRepository ArticleRepository) : IArticleService
    {
        private IArticleRepository _articleRepository = ArticleRepository; 

        public ArticleDTO GetArticle(long Article_ID) 
        {
            return _articleRepository.Get(Article_ID); 
        }

        public List<ArticleDTO> GetArticlies()  
        {
            return _articleRepository.GetArticlies(); 
        }

        public void InsertArticle(CreateArticle dto) 
        {
            _articleRepository.Insert(dto);  
        }

        public void UpdateArticle(UpdateArticle dto)  
        {
            _articleRepository.Update(dto); 
        }

        public void DeleteArticle(long Article_ID)  
        {
            _articleRepository.Delete(Article_ID);  
        }
    }
}
