using cursach_3.DATA;

namespace cursach_3.DTO.Commentary
{
    public class CommentaryDTO
    {
        public long Commentary_ID { get; set; }
        public int Topic_ID { get; set; }
        public int Thread_ID { get; set; }
        public int User_ID { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Commentary_size { get; set; }
        public int Article_ID { get; set; }
        public User.UserDTO User { get; set; }

        public Thread.ThreadDTO Thread { get; set; }
        public Topic.TopicDTO Topic { get; set; }

        public Article.ArticleDTO Article { get; set; }

        public File_Archive.File_ArchiveDTO File { get; set; }
    }
}
