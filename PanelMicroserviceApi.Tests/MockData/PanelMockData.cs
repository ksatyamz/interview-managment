using PanelMicroservice.Models.Domain;

namespace PanelMicroserviceApi.Tests.MockData
{
    public static class PanelMockData
    {
        public static List<Panel> GetPanelsAsync()
        {
            return new List<Panel>
            {
                new(){Id = 1, PanelId=1, EmpId=1},
                new(){Id = 2, PanelId=1, EmpId=2},
                new(){Id = 3, PanelId=1, EmpId=3},
                new(){Id = 4, PanelId=2, EmpId=3},
                new(){Id = 5, PanelId=2, EmpId=1}
            };
        }
        public static List<Panel> EmptyPanelList()
        {
            return null;
        }

        public static Panel panel()
        {
            return new Panel()
            {
                Id= 3,
                PanelId = 2,
                EmpId = 1,
            };

        }


       

        public static Panel EmptyPanel()
        {
            return null;
        }

    }
}