using cursach_3.DATA;

namespace cursach_3.DTO.Commentary
{
    public class UpdateCommentary
    {
        public long Commentary_ID { get; set; }
        public long Topic_ID { get; set; }
        public long Thread_ID { get; set; }
        public long User_ID { get; set; }
        public DateTime Creation_Date { get; set; }
        public string Commentary_size { get; set; }
        public long Article_ID { get; set; }
        
    }
}
