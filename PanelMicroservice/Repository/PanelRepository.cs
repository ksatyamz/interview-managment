using Microsoft.EntityFrameworkCore;
using PanelMicroservice.Data;
using PanelMicroservice.Models.Domain;

namespace PanelMicroservice.Repository
{
    public class PanelRepository : IPanelRepository
    {
        public readonly PanelDbContext PanelDbContext;
        public PanelRepository(PanelDbContext _interviewDbContext)
        {
            PanelDbContext = _interviewDbContext;
        }

        public async Task<Panel> AddPanelAsync(Panel panel)
        {
            var check = await PanelDbContext.panels.FirstOrDefaultAsync(x=> x.PanelId==panel.PanelId && x.EmpId==panel.EmpId);
            if (check == null)
            {
                await PanelDbContext.AddAsync(panel);
                await PanelDbContext.SaveChangesAsync();
                return panel;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Panel>> DelPanelAsync(int id)
        {
            var pan = await PanelDbContext.panels.Where(x => x.PanelId == id).ToListAsync();
            if (pan.Count == 0)
            {
                return null;
            }
            else {
                foreach (var panel in pan)
                {
                    PanelDbContext.panels.Remove(panel);
                    await PanelDbContext.SaveChangesAsync();
                }
            }
            return pan;
        }

        public async Task<Panel> DelPanelByIdAsync(int PanelId, int EmpId)
        {
            var pan = await PanelDbContext.panels.FirstOrDefaultAsync(x=> x.PanelId == PanelId && x.EmpId==EmpId);
            if(pan != null)
            {
                PanelDbContext.panels.Remove(pan);
                await PanelDbContext.SaveChangesAsync();

                return pan;
            }
            else
            {
                return null;
            }

        }

        public async Task<Panel> GetPanelByIdAsync(int id)
        {
            return await PanelDbContext.panels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Panel>> GetPanelsAsync()
        {
            return await PanelDbContext.panels.ToListAsync();
        }
        public async Task<IEnumerable<Panel>> GetEmpByIdAsync(int id)
        {
            var emp = await PanelDbContext.panels.Where(x => x.EmpId == id).ToListAsync();
            if (emp.Count == 0)
            {
                return null;
            }
            else
            {
                return emp;
            }
        }

    }
}
