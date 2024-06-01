using cursach_3.DATA;

namespace cursach_3.DTO.File_Archive
{
    public class File_ArchiveDTO
    {
        public int File_Archive_ID { get; set; }
        public int Topic_ID { get; set; }
        public int Thread_ID { get; set; }
        public long Commentary_ID { get; set; }
        public string Files_Archive_Desc { get; set; }
        public string File_Path { get; set; }
        public long Article_ID { get; set; }
        public Topic.TopicDTO Topic { get; set; }
        public Thread.ThreadDTO Thread { get; set; }
        public Commentary.CommentaryDTO Commentary { get; set; }
        public Article.ArticleDTO Article { get; set; }
    }
}
