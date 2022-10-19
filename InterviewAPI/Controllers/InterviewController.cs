using AutoMapper;
using InterviewMicroserviceApi.Models.Domain;
using InterviewMicroserviceApi.Models.Dto;
using InterviewMicroserviceApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InterviewMicroserviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterviewRepository interviewRepository;
        private readonly IMapper mapper;
        public InterviewController(IInterviewRepository _interviewRepository, IMapper _mapper)
        {
            interviewRepository = _interviewRepository;
            mapper = _mapper;
        }

        [HttpGet]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetInterAsync()
        {
            var allinterviews = await interviewRepository.GetInterviewsAsync();
            if (allinterviews.Count() == 0)
                return NoContent();
             
            var interviewsDto = mapper.Map<List<InterviewDto>>(allinterviews);
            return Ok(interviewsDto);

        }

        [HttpGet("InterviewId")]
       // [Authorize]
        public async Task<IActionResult> GetInterByIdAsync(int id)
        {
            var interview = await interviewRepository.GetInterviewByIdAsync(id);
            if(interview==null)
                return NoContent();
            
            var interviewDto = mapper.Map<InterviewDto>(interview);
            return Ok(interviewDto);

        }
        [HttpGet("CandidateId")]
        //[Authorize]
        public async Task<IActionResult> GetInterByCadIdAsync(int id)
        {
            var interview = await interviewRepository.GetInterviewByCadIdAsync(id);
            if (interview.Count() == 0)
                return NoContent();
            var interviewDto = mapper.Map<List<InterviewDto>>(interview);
            return Ok(interviewDto);

        }

        [HttpGet("PanelId")]
       // [Authorize]
        public async Task<IActionResult> GetInterByPanIdAsync(int id)
        {
            var interview = await interviewRepository.GetInterviewByPanIdAsync(id);
            if (interview.Count() == 0)
                return NoContent();
                var interviewDto = mapper.Map<List<InterviewDto>>(interview);
            return Ok(interviewDto);

        }

        [HttpPost]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddInterviewAsync(Interview interview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var inter = new Interview()
                {
                    PanelId = interview.PanelId,
                    CandidateId = interview.CandidateId,
                    DateTime = interview.DateTime,
                    Duration = interview.Duration

                };
                var interv = await interviewRepository.AddInterviewAsync(inter);

                var interDto = mapper.Map<InterviewDto>(interv);

                return Ok(interDto);


            }
        }
        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateInterviewAsync(Interview interview, int id)
        {
            var inter = await interviewRepository.UpdateInterviewAsync(interview, id);
            if (inter == null)
            {
                return NoContent();
            }
            
                var interDto = mapper.Map<InterviewDto>(inter);
                return Ok(interDto);
            
        }
        [HttpDelete("CadId")]
        public async Task<IActionResult> DeleteInterviewAsync(int cadId)
        {
            var interview= await interviewRepository.DeleteInterviewAsync(cadId);
            if(interview == null)
                return NotFound();

            var InterDto=mapper.Map<InterviewDto>(interview);
            return Ok(InterDto);
        }


    }
}
