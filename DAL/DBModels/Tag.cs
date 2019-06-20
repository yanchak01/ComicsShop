using DAL.MainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DBModels
{
    public class Tag:Entity
    {
        public string Name { get; set; }
        public ICollection<TagComics> TagComicses { get; set; }
    }
}
