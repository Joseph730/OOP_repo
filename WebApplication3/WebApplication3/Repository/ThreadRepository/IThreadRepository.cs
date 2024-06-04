

using cursach_3.DTO.Thread;

namespace cursach_3.Repository.ThreadRepository;

    public interface IThreadRepository
    {
        ThreadDTO Get(long Thread_ID);
        List<ThreadDTO> GetThreads();
        void Insert(CreateThread dto);
        void Update(UpdateThread dto);
        void Delete(long Thread_ID);
    }

