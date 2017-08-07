﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class MenuData
    {
        public int GroupID { get; set; }

        public string GroupName { get; set; }

        public IEnumerable<MenuItem> MenuItems { get; set; }
    }
}
