using System.ComponentModel.DataAnnotations;
namespace Model.DTOs
{
    public class TypographerDTO
    {
        public PositionsEnum Position = PositionsEnum.Typographer;
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
