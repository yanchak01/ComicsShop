using System.ComponentModel.DataAnnotations;

namespace Model.MainModelsDTO
{
    public class ComicsAuthorDTO:EntityDTO
    {
        public PositionsEnum Position { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
