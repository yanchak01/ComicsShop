﻿using System;

namespace DAL.DBModels
{
    public class ComicsAuthorComics
    {
        public Guid ComicsAuthorId { get; set; }
        public ComicsAuthor ComicsAuthor { get; set; }
        public Guid ComicsId { get; set; }
        public Comics Comics { get; set; }
    }
}
