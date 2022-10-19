using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PanelMicroservice.Models.Domain
{
    public class Panel
    {
        [Key]
        public int Id { get; set; }
        public  int PanelId { get; set; }
        
        public int EmpId { get; set; }
       
    }
}
