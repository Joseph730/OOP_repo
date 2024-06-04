using cursach_3.DATA;

namespace cursach_3.DTO.Thread
{
    public class UpdateThread
    {
        public long Thread_ID { get; set; }
        public string Thread_Desc { get; set; }
        public string Thread_Name { get; set; }
        public long Author_ID { get; set; }
        public long Rating { get; set; }
        public string Thread_URL { get; set; }
    }
}
