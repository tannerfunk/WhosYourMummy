﻿using System;
using System.Collections.Generic;

namespace WhosYourMummy.Models
{
    public partial class Dimension
    {
        public long Id { get; set; }
        public string? Dimensiontype { get; set; }
        public string? Value { get; set; }
        public int? Dimensionid { get; set; }
    }
}
