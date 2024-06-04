using cursach_3.DATA;

namespace cursach_3.DTO.Thread
{
    public class ThreadDTO
    {
        public long Thread_ID { get; set; }
        public string Thread_Desc { get; set; }
        public string Thread_Name { get; set; }
        public long Author_ID { get; set; }
        public long Rating { get; set; }
        public string Thread_URL { get; set; }
        public List<Commentary.CommentaryDTO> Commentary_List { get; set; }
        public List<Topic.TopicDTO> Topic_List { get; set; }
        public List<File_Archive.File_ArchiveDTO> File_List { get; set; }
        public Author.AuthorDTO Author { get; set; }
    }
}
