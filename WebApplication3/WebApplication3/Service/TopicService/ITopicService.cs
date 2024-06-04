using cursach_3.DTO.Topic;

namespace cursach_3.Service.TopicService
{
    public interface ITopicService
    {
        TopicDTO GetTopic(long Topic_ID); 
        List<TopicDTO> GetTopics(); 
        void InsertTopic( CreateTopic dto);  
        void UpdateTopic(UpdateTopic dto);  
        void DeleteTopic(long Topic_ID);
    }
}
