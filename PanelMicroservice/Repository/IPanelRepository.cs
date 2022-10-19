using PanelMicroservice.Models.Domain;

namespace PanelMicroservice.Repository
{
    public interface IPanelRepository
    {
        Task<Panel> GetPanelByIdAsync(int id);
        Task<IEnumerable<Panel>> GetPanelsAsync();
        Task<IEnumerable<Panel>> DelPanelAsync(int id);
        Task<Panel> DelPanelByIdAsync(int PanelId, int EmpId );

        Task<Panel> AddPanelAsync(Panel panel);
        Task<IEnumerable<Panel>> GetEmpByIdAsync(int id);
    }
}
