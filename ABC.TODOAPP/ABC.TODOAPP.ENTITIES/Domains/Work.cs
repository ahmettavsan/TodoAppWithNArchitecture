﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC.TODOAPP.ENTITIES.Domains
{
    public class Work:BaseEntity
    {
      
        public string Definition { get; set; }
        public bool IsComplated { get; set; }

    }
}
