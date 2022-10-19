using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PanelMicroservice.Models.Dto
{
    public class PanelDto
    {
        [Key]
        public int Id { get; set; }
        public int PanelId { get; set; }
        
        public int EmpId { get; set; }

    }
}
