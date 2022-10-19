using InterviewPanelManagement.Data;
using InterviewPanelManagement.Models.Domain;
using InterviewPanelManagement.Repositiory;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repositories
{
    namespace InterviewPanelManagement.Repositiory
    {
        public class CandidateRepository : ICandidateRepository

        {
            private readonly InterviewDbContext interviewDbContext;


            public CandidateRepository(InterviewDbContext _interviewDbContext)
            {
                interviewDbContext = _interviewDbContext;
            }
            public async Task<Candidate> AddCandidateAsync(Candidate candidate)
            {
                await interviewDbContext.AddAsync(candidate);
                await interviewDbContext.SaveChangesAsync();
                return candidate;
            }

            public async Task<Candidate> DeleteCandidateAsync(int id)
            {
                var cdt = await interviewDbContext.candidates.SingleAsync(x => x.CandidateId == id);
                if (cdt == null)
                {
                    return null;
                }
                else
                {
                    interviewDbContext.Remove(cdt);
                    await interviewDbContext.SaveChangesAsync();
                }
                return cdt;
            }

            public async Task<Candidate> GetCandidateAsync(int id)
            {
                return await interviewDbContext.candidates.FirstOrDefaultAsync(x => x.CandidateId == id);
            }

            public async Task<IEnumerable<Candidate>> GetCandidatesAsync()
            {
                return await interviewDbContext.candidates.ToListAsync();
            }
        }
    }
}