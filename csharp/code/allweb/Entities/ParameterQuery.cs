﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ParameterQuery
    {
        public ParameterQuery() { }

        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int total { get; set; }
    }
}
