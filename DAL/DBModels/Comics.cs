﻿using DAL.MainModels;
using System.Collections.Generic;


namespace DAL.DBModels
{
    public class Comics:Entity
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
        public string Series { get; set; }
        public int Price { get; set; }
        public ComicsType ComicsType { get; set; }
        public ICollection<TagComics> Tags { get; set; }
        public ICollection<ComicsAuthorComics> ComicsAuthors { get; set; }

    }
}
