﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TimelineDLL.ViewModels
{
    public class TimePeriodViewModel
    {
        public int TimePeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
    }
}
