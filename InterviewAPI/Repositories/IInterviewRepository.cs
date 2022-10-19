using InterviewMicroserviceApi.Models.Domain;

namespace InterviewMicroserviceApi.Repositories
{
    public interface IInterviewRepository
    {
        Task<IEnumerable<Interview>> GetInterviewsAsync();
        Task<IEnumerable<Interview>> GetInterviewByCadIdAsync(int id);

        Task<IEnumerable<Interview>> GetInterviewByPanIdAsync(int id);
        Task<Interview> GetInterviewByIdAsync(int id);
        Task<Interview> AddInterviewAsync(Interview interview);

        Task<Interview> UpdateInterviewAsync(Interview interview,int id);

        Task<Interview> DeleteInterviewAsync(int cadId);
        

    }
}
