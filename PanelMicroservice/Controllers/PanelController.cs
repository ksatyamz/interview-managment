using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelMicroservice.Models.Domain;
using PanelMicroservice.Models.Dto;
using PanelMicroservice.Repository;

namespace PanelMicroserviceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PanelController : ControllerBase
    {
        private readonly IPanelRepository PanelRepository;
        private readonly IMapper mapper;

        public PanelController(IPanelRepository _panelRepository, IMapper _mapper)
        {
            PanelRepository = _panelRepository;
            mapper = _mapper;
        }

        [HttpGet("PanelId={id:int}")]
       // [Authorize]
        public async Task<IActionResult> GetPanelByIdAsync(int id)
        {

            var pnl = await PanelRepository.GetPanelByIdAsync(id);
            if (pnl == null)
            {
                return NoContent();
            }
            var panel = await PanelRepository.GetPanelByIdAsync(id);
            var panelDto = mapper.Map<PanelDto>(panel);
            return Ok(panelDto);
        }


        [HttpGet]
       // [Authorize]

        public async Task<IActionResult> GetPanelsAsync()
        {
            var allPanel = await PanelRepository.GetPanelsAsync();

            if (allPanel == null)
            {
                return NoContent();
            }
            var panelDto = mapper.Map<List<PanelDto>>(allPanel);
            return Ok(panelDto);
        }

        [HttpDelete]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DelPanelAsync(int id)
        {
            var panel = await PanelRepository.DelPanelAsync(id);
            if (panel == null)
            {
                return NotFound();
            }
            else
            {
                //var panelDto = mapper.Map<PanelDto>(panel);
                return Ok(panel); // + "Sucessfully Deleted the Id : " + id);
            }
        }

        [HttpDelete("id")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult>DelPanelByIdAsync(int PanelId, int EmpId)
        {
            var pan= await PanelRepository.DelPanelByIdAsync(PanelId, EmpId);
            if(pan == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(mapper.Map<PanelDto>(pan));
            }
        }
        [HttpGet("EmpId={id:int}")]
        public async Task<IActionResult> GetEmpByIdAsync(int id)
        {

            var emp = await PanelRepository.GetEmpByIdAsync(id);
            if (emp == null)
            {
                return NoContent();
            }
            var employee = await PanelRepository.GetEmpByIdAsync(id);
            var panelDto = mapper.Map<List<PanelDto>>(employee);
            return Ok(panelDto);
        }




        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPanelAsync(Panel panel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                

                var p = await PanelRepository.AddPanelAsync(panel);
                if (p != null)  {
                    var panDto = mapper.Map<Panel>(p);
                    return Ok(panDto);
                }
                else
                {
                    return Conflict();
                }
                
            }
        }
    }
}
