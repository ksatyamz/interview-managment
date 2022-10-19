using InterviewPanelManagement.Models.Domain;

namespace InterviewPanelManagement.Repositiory
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetCandidatesAsync();
        Task<Candidate> GetCandidateAsync(int id);
        Task<Candidate> AddCandidateAsync(Candidate candidate);
       // Task<Candidate>UpdateCandidateAsync(Candidate candidate);
        Task <Candidate>DeleteCandidateAsync(int id);

    }
}
