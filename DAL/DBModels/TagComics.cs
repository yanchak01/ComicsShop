﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DBModels
{
    public class TagComics
    {
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
        public Guid ComicsId { get; set; }
        public Comics Comics { get; set; }
    }
}
