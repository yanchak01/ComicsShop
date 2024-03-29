﻿using System;
using System.Collections.Generic;

namespace ComicsShop.DTO
{
    public class ComicsDTO : EntityDTO
    {
        
        public string Name { get; set; }
        
        public int PageCount { get; set; }
       
        public string Description { get; set; }
       
        public string Series { get; set; }
        
        public double Price { get; set; }
     
        public ComicsType ComicsType { get; set; }

        public ICollection<ComicsAuthorDTO> ComicsAuthors { get; set; }
    }
}
