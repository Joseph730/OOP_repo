
using cursach_3.DTO.Commentary;
using cursach_3.Repository.CommentaryRepository;


namespace cursach_3.Service.CommentaryService
{
    public class CommentaryService(ICommentaryRepository CommentaryRepository) : ICommentaryService
    {
        private ICommentaryRepository _commentaryRepository = CommentaryRepository; 

        public CommentaryDTO GetCommentary(long Commentary_ID) 
        {
            return _commentaryRepository.Get(Commentary_ID); 
        }

        public List<CommentaryDTO> GetCommentaries()  
        {
            return _commentaryRepository.GetCommentaries(); 
        }

        public void InsertCommentary(CreateCommentary dto) 
        {
            _commentaryRepository.Insert(dto);  
        }

        public void UpdateCommentary(UpdateCommentary dto)  
        {
            _commentaryRepository.Update(dto); 
        }

        public void DeleteCommentary(long Commentary_ID)  
        {
            _commentaryRepository.Delete(Commentary_ID);  
        }
    }
}
