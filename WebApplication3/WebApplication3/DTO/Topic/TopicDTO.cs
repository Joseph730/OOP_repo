using cursach_3.DATA;

namespace cursach_3.DTO.Topic
{
    public class TopicDTO
    {
        public long Topic_ID { get; set; }
        public string Topic_Name { get; set; }
        public long Thread_ID { get; set; }
        public string Topic_URL { get; set; }
        public string Topic_Desc { get; set; }
        public Thread.ThreadDTO Thread { get; set; }
        public List<Commentary.CommentaryDTO> Commentary_List { get; set; } = [];
        public List<File_Archive.File_ArchiveDTO> File_List { get; set; } = [];
    }
}
