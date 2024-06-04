using cursach_3.DTO.Thread;

namespace cursach_3.Service.ThreadService
{
    public interface IThreadService
    {
        ThreadDTO GetThread(long Thread_ID); 
        List<ThreadDTO> GetThreads(); 
        void InsertThread(CreateThread dto);  
        void UpdateThread(UpdateThread dto);  
        void DeleteThread(long Thread_ID);
    }
}
