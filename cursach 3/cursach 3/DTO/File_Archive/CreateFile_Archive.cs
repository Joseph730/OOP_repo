using cursach_3.DATA;

namespace cursach_3.DTO.File_Archive
{
    public class CreateFile_Archive
    {
        public int Topic_ID { get; set; }
        public int Thread_ID { get; set; }
        public long Commentary_ID { get; set; }
        public string Files_Archive_Desc { get; set; }
        public string File_Path { get; set; }
        public long Article_ID { get; set; }
        public Topic_DATA Topic { get; set; }
        public Thread_DATA Thread { get; set; }
        public Commentary_DATA Commentary { get; set; }
        public Article_DATA Article { get; set; }
    }
}
