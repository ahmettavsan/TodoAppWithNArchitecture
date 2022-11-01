using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.DTOs.WorkDTOs
{
    public class WorkUpdateDTos: IDTO
    {
        //[Range(1,int.MaxValue,ErrorMessage ="Id is required")]
        public int Id { get; set; }
        //[Required(ErrorMessage ="Defination is required")]
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
