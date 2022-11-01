using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.DTOs.WorkDTOs
{
    public class WorkCreateDto: IDTO
    {
        [Required]
        public string Definition { get; set; }
        public bool IsComplated { get; set; }
    }
}
