
using cursach_3.DTO.Commentary;

namespace cursach_3.Service.CommentaryService
{
    public interface ICommentaryService
    {
        CommentaryDTO GetCommentary(long Commentary_ID); 
        List<CommentaryDTO> GetCommentaries(); 
        void InsertCommentary(CreateCommentary dto);  
        void UpdateCommentary(UpdateCommentary dto);  
        void DeleteCommentary(long Commentary_ID);
    }
}
