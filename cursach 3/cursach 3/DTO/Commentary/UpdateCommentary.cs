using cursach_3.DATA;

namespace cursach_3.DTO.Commentary
{
    public class UpdateCommentary
    {
        public long Commentary_ID { get; set; }
        public int Topic_ID { get; set; }
        public int Thread_ID { get; set; }
        public int User_ID { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Commentary_size { get; set; }
        public int Article_ID { get; set; }
        public User_DATA User { get; set; }

        public Thread_DATA Thread { get; set; }
        public Topic_DATA Topic { get; set; }

        public Article_DATA Article { get; set; }

        public File_Archive_DATA File { get; set; }
    }
}
