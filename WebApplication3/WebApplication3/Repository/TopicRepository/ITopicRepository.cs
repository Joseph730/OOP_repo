using cursach_3.DTO.Article;
using cursach_3.DTO.Topic;

namespace cursach_3.Repository.TopicRepository
{
    public interface ITopicRepository
    {
        TopicDTO Get(long Topic_ID);
        List<TopicDTO> GetTopics();
        void Insert( CreateTopic dto);
        void Update(UpdateTopic dto);
        void Delete(long Topic_ID);
    }
}
