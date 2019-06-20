using Model.MainModelsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.DTOs
{
    public class ComicsDTO : EntityDTO
    {
        [Display(Name ="Name")]
        public string Name { get; set; }
        [Display(Name = "NumbersOfPages")]
        public int NumbersOfPages { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Series")]
        public string Series { get; set; }
        [Display(Name = "Price")]
        public int Price { get; set; }
        [Display(Name = "TypesComics")]
        public TypesComicsEnum TypesComics { get; set; }

        public ICollection<ComicsAuthorDTO> ComicsAuthors { get; set; }
    }
}
