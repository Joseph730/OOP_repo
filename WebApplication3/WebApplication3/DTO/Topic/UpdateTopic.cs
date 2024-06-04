using cursach_3.DATA;

namespace cursach_3.DTO.Topic
{
    public class UpdateTopic
    {
        public long Topic_ID{ get; set; }
        public string Topic_Name { get; set; }
        public long Thread_ID { get; set; }
        public string Topic_URL { get; set; }
        public string Topic_Desc { get; set; }
    }
}
