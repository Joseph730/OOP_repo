using cursach_3.DATA;

namespace cursach_3.DTO.Topic
{
    public class TopicDTO
    {
        public int Topic_ID;
        public string Topic_Name;
        public int Thread_ID;
        public string Topic_URL;
        public string Topic_Desc;
        public int Event_ID;
        public Thread.ThreadDTO Thread;
        public List<Commentary.CommentaryDTO> Commentary_List { get; set; } = [];
        public List<File_Archive.File_ArchiveDTO> File_List { get; set; } = [];
    }
}
