using cursach_3.DTO.Thread;
using cursach_3.Repository.ThreadRepository;
using cursach_3.Service.ThreadService;

namespace cursach_3.Service.ThreadService
{
    public class ThreadService(IThreadRepository ThreadRepository) : IThreadService
    {
        private IThreadRepository _threadRepository = ThreadRepository; 

        public ThreadDTO GetThread(long Thread_ID) 
        {
            return _threadRepository.Get(Thread_ID); 
        }

        public List<ThreadDTO> GetThreads()  
        {
            return _threadRepository.GetThreads(); 
        }

        public void InsertThread(CreateThread dto) 
        {
            _threadRepository.Insert(dto);  
        }

        public void UpdateThread(UpdateThread dto)  
        {
            _threadRepository.Update(dto); 
        }

        public void DeleteThread(long Thread_ID)  
        {
            _threadRepository.Delete(Thread_ID);  
        }
    }
}
