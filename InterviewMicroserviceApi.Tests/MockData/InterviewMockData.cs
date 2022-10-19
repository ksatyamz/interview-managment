using InterviewMicroserviceApi.Models.Domain;

namespace InterviewMicroserviceApi.Tests.MockData
{
    public class InterviewMockData
    {
        public static List<Interview> GetInterviews()
        {
            var allInterviews = new List<Interview>()
            {
                new Interview{InterviewId=1,PanelId=1,CandidateId=1,DateTime=new DateTime(2022,09,28,11,30,00),Duration=1},
                new Interview{InterviewId=2,PanelId=1,CandidateId=2,DateTime=new DateTime(2022,09,29,11,30,00),Duration=1},
                new Interview{InterviewId=3,PanelId=1,CandidateId=3,DateTime=new DateTime(2022,09,30,11,30,00),Duration=1}
            };
            return allInterviews;

        }
        public static List<Interview> GetEmptyList()
        {
            return new List<Interview>();
        }
        public static Interview GetInterview()
        {
            var interview = new Interview()
            { 
                InterviewId=1,
                PanelId = 1,
                CandidateId = 1,
                DateTime = new DateTime(2023, 08, 09, 12, 00, 00),
                Duration = 1

            };
            return interview;
        }
        public static Interview GetEmptyInterview()
        {
            return null;
        }
        public static Interview Interview()
        {
            var interview = new Interview()
            {
                
                PanelId = 1,
                CandidateId = 1,
                DateTime = new DateTime(2023, 08, 09, 12, 00, 00),
                Duration = 1

            };
            return interview;
        }

    }
}
