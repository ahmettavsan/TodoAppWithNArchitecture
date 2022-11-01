using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.DTOs.WorkDTOs
{
    public class WorkListDTO: IDTO
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public bool IsComplated { get; set; }   
    }
}
