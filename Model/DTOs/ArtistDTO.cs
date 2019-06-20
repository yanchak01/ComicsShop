using Model.MainModelsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.DTOs
{
    public class ArtistDTO:EntityDTO
    {
        public string Position = PositionsEnum.Artist.ToString();
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
