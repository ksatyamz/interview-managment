using InterviewPanelManagement.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateMicroServiceAPI.Test.MockData
{
    public static class CandidateMockData
    {
        public static List<Candidate> GetCandidates()
        {
            return new List<Candidate> 
            {
                new(){ CandidateId=1,FirstName="Abhishek",LastName="krishna",Email="abhishek@gmail.com",Phone=9801898775,Primary_skill="C",Secondary_skill="C++",Designation="SDE",Experience="3 Months",Qualification="B.Tech",NoticePeriod="3 years",
                location="Pune"},
               new(){ CandidateId=2,FirstName="Sumit",LastName="Mandal",Email="mandalsumit@gmail.com",Phone=7667249065,Primary_skill="C",Secondary_skill="C++",Designation="SDE",Experience="3 Months",Qualification="B.Tech",NoticePeriod="3 years"
                 ,location="Delhi"},
               new(){ CandidateId=3,FirstName="Ashee",LastName="Jain",Email="a.jain4@gmail.com",Phone=7667249095,Primary_skill="C",Secondary_skill="C++",Designation="SDE",Experience="2 months",Qualification="B.Tech",NoticePeriod="3 years"
                 ,location="UP"}
            };
        }
        public static List<Candidate> EmptyCandidatesList()
        {
            return new List<Candidate>();
        }

        public static Candidate candidate()
        {
            return new Candidate()
            {
                CandidateId = 5,
                FirstName = "Ashee",
                LastName = "Jain",
                Email = "a.jain4@gmail.com",
                Phone = 7667249095,
                Primary_skill="C",
                Secondary_skill="C++",
                Designation="SDE",
                Experience = "3 years",
                Qualification = "B.Tech",
                NoticePeriod = "3 Months",
                location = "UP"
            };



        }

        public static Candidate EmptyCandiadte()
        {
            return null;
        }

        public static Candidate AddCandidate()
        {
            return new Candidate()
            {
                FirstName = "Ashee",
                LastName = "Jain",
                Email = "a.jain4@gmail.com",
                Phone = 7667249095,
                Primary_skill = "C",
                Secondary_skill = "C++",
                Designation = "SDE",
                Experience = "3 Years",
                Qualification = "B.Tech",
                NoticePeriod = "3 Months"
                 ,
                location = "UP"
            };
        }

    }

}
