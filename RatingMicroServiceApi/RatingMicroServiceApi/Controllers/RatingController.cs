using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RatingMicroServiceApi.Models.Domain;
using RatingMicroServiceApi.Models.Dto;
using RatingMicroServiceApi.Repositories;

namespace RatingMicroServiceApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RatingController:ControllerBase
    {
        private readonly IRatingRepository ratingRepository;
        private readonly IMapper mapper;
        public RatingController(IRatingRepository _ratingrepository, IMapper _mapper)
        {
            ratingRepository = _ratingrepository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRatAsync()
        {
            var allRat = await ratingRepository.GetRatingsAsync();
            if (allRat.Count() == 0)
            {
                return NoContent();
            }
            var ratDto = mapper.Map<List<RatingDto>>(allRat);
            return Ok(ratDto);

        }
        [HttpPost]
        public async Task<IActionResult> AddRatAsync(Rating rating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {

                var ratModel = new Rating()
                {
                    TechRating = rating.TechRating,
                    TechComment = rating.TechComment,
                    CandidateId = rating.CandidateId,
                    //HrComment = rating.HrComment,
                    //HrRating = rating.HrRating,
                };

                rating = await ratingRepository.AddRatingAsync(ratModel);
                var ratDto = mapper.Map<RatingDto>(rating);
                return Created("SuccessfullyCreated",ratDto);


            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetRatByIdAsync(int id)
        {
            var rat = await ratingRepository.GetRatingAsync(id);
            if (rat == null)
            {
                return NoContent();
            }
            var ratDto = mapper.Map<RatingDto>(rat);
            return Ok(ratDto);
        }
        [HttpPut("id")]
        public async Task<IActionResult> UpdateHrRatAsync(int id, Rating rating)
        {
            var rat = await ratingRepository.UpdateHrRatingAsync(id, rating);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (rat == null)
            {
                return NotFound();
            }
            var ratDto = mapper.Map<RatingDto>(rat);
            return Ok(ratDto);
        }
        [HttpPut("status")]
        public async Task<IActionResult> UpdStatusAsync(int id, Rating rating)
        {
            var rat = await ratingRepository.UpdateStatusAsync(id, rating);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (rat == null)
            {
                return NotFound();
            }
            var ratDto = mapper.Map<RatingDto>(rat);
            return Ok(ratDto);
        }


    }
}
