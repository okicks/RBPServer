﻿using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Liquor
{
    public class LiquorDetail
    {
        public string Name { get; set; }

        public LiquorCategory Category { get; set; }

        [DisplayName("% Alcohol")]
        public float PercentAlcohol { get; set; }

        public string Origin { get; set; }

    }
}
