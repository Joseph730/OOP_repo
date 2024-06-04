using cursach_3.DTO.Topic;
using cursach_3.Repository.TopicRepository;
using cursach_3.Service.TopicService;

namespace cursach_3.Service.TopicService
{
    public class TopicService(ITopicRepository TopicRepository) : ITopicService
    {
        private ITopicRepository _topicRepository = TopicRepository; 

        public TopicDTO GetTopic(long Topic_ID) 
        {
            return _topicRepository.Get(Topic_ID); 
        }

        public List<TopicDTO> GetTopics()  
        {
            return _topicRepository.GetTopics(); 
        }

        public void InsertTopic( CreateTopic dto) 
        {
            _topicRepository.Insert(dto);  
        }

        public void UpdateTopic(UpdateTopic dto)  
        {
            _topicRepository.Update(dto); 
        }

        public void DeleteTopic(long Topic_ID)  
        {
            _topicRepository.Delete(Topic_ID);  
        }
    }
}
