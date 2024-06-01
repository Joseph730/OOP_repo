using cursach_3.DATA;

namespace cursach_3.DTO.Topic
{
    public class UpdateTopic
    {
        public int Topic_ID;
        public string Topic_Name;
        public int Thread_ID;
        public string Topic_URL;
        public string Topic_Desc;
        public int Event_ID;
        public Thread_DATA Thread;
        public Event_DATA Event;
    }
}
