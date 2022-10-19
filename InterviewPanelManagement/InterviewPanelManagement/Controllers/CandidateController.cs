using AutoMapper;
using InterviewPanelManagement.Models.Domain;
using InterviewPanelManagement.Models.Dto;
using InterviewPanelManagement.Repositiory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace InterviewPanelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CandidateController : ControllerBase
    {

        private readonly ICandidateRepository candidateRepository;
        private readonly IMapper mapper;
        public CandidateController(ICandidateRepository _candidateRepository, IMapper _mapper)
        {
            candidateRepository = _candidateRepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCdtAsync()
        {
            var allcdt = await candidateRepository.GetCandidatesAsync();
            if(allcdt.Count() == 0)
            {
                return NoContent();
            }
            var cdtDto = mapper.Map<List<CandidateDto>>(allcdt);
            return Ok(cdtDto);

        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByCdtIdAsync(int id)
        {

            var allcdt = await candidateRepository.GetCandidateAsync(id);
            if(allcdt == null)
            {
                return NoContent();
            }
            var cdtDto = mapper.Map<CandidateDto>(allcdt);
            return Ok(cdtDto);

        }

        [HttpPost]
        public async Task<IActionResult> AddCdtAsync(Candidate cdt)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var cdtModel = new Candidate()
                {
                    FirstName = cdt.FirstName,
                    LastName = cdt.LastName,
                    Email = cdt.Email,
                    Phone = cdt.Phone,
                    Primary_skill = cdt.Primary_skill,
                    Secondary_skill = cdt.Secondary_skill,
                    Designation = cdt.Designation,
                    Experience = cdt.Experience,
                    Qualification = cdt.Qualification,
                    NoticePeriod = cdt.NoticePeriod,
                    location = cdt.location
                };
                cdt = await candidateRepository.AddCandidateAsync(cdtModel);

                var cdtDto = mapper.Map<CandidateDto>(cdt);

                return Created("Created Successfully",cdtDto);


            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCandidateAsync(int id)
        {
            var cdt = await candidateRepository.DeleteCandidateAsync(id);
            if (cdt == null)
            {
                return NotFound();
            }
            var cdtDto = mapper.Map<CandidateDto>(cdt);
            return Ok(cdtDto);
        }
    }
}

    
