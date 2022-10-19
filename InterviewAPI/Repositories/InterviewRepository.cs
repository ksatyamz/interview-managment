using InterviewMicroserviceApi.Data;
using InterviewMicroserviceApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace InterviewMicroserviceApi.Repositories
{
    public class InterviewRepository : IInterviewRepository
    {
        private readonly InterviewDbContext interviewDbContext;


        public  InterviewRepository(InterviewDbContext _interviewDbContext)
        {
            interviewDbContext = _interviewDbContext;
        }
        public async Task<Interview> AddInterviewAsync(Interview interview)
        {
            await interviewDbContext.AddAsync(interview);
            await interviewDbContext.SaveChangesAsync();
            return interview;
        }

        public async Task<Interview> DeleteInterviewAsync(int cadId)
        {
            var interview =await interviewDbContext.interviews.SingleAsync(x=>x.CandidateId==cadId);
            if (interview == null)
                return null;

            interviewDbContext.Remove(interview);
           await interviewDbContext.SaveChangesAsync();
            return interview;
        }

        public async Task<IEnumerable<Interview>> GetInterviewByCadIdAsync(int id)
        {
            var interviews= new List<Interview>();
            var inters= await interviewDbContext.interviews.ToListAsync();
            foreach(var inter in inters)
            {
                if(inter.CandidateId==id)
                    interviews.Add(inter);
            }
            return interviews;
        }

        

        public async Task<Interview> GetInterviewByIdAsync(int id)
        {
             return await interviewDbContext.interviews.FirstOrDefaultAsync(x => x.InterviewId == id);
        }

        public async Task<IEnumerable<Interview>> GetInterviewByPanIdAsync(int id)
        {
            var interviews = new List<Interview>();
            var inters = await interviewDbContext.interviews.ToListAsync();
            foreach (var inter in inters)
            {
                if (inter.PanelId == id)
                    interviews.Add(inter);
            }
            return interviews;
        }

        public async Task<IEnumerable<Interview>> GetInterviewsAsync()
        {
            return await interviewDbContext.interviews.ToListAsync();
        }

        public async Task<Interview> UpdateInterviewAsync(Interview interview, int id)
        {
            var result = await interviewDbContext.interviews.FirstOrDefaultAsync(x => x.InterviewId == id);
            if (result == null)
            {
                return null;
            }
            else
            {
                result.CandidateId = interview.CandidateId;
                result.PanelId = interview.PanelId;
                result.DateTime = interview.DateTime;
                result.Duration = interview.Duration;
                interviewDbContext.Update(result);
                await interviewDbContext.SaveChangesAsync();

            }
            return result;
        }
        
    }
    
}
