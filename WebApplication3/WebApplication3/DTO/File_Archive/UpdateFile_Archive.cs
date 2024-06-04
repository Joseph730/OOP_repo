using cursach_3.DATA;

namespace cursach_3.DTO.File_Archive
{
    public class UpdateFile_Archive
    {
        public long File_Archive_ID { get; set; }
        public long Topic_ID { get; set; }
        public long Thread_ID { get; set; }
        public long Commentary_ID { get; set; }
        public string Files_Archive_Desc { get; set; }
        public string File_Path { get; set; }
        public long Article_ID { get; set; }
       
    }
}
