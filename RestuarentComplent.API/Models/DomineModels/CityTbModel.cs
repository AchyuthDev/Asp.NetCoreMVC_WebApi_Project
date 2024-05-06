using System.ComponentModel.DataAnnotations;

namespace RestuarentComplent.API.Models.DomineModels
{
    public class CityTbModel
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }

        public virtual CountyTbModel Country { get; set; }
    }
}
