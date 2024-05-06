using System.ComponentModel.DataAnnotations;

namespace RestuarentComplent.API.Models.DomineModels
{
    public class CountyTbModel
    {
        [Key]
        public int CountryId { get; set; }

        public ICollection<CityTbModel> Citys { get; set; }
        public string CountryName { get; set; }
    }
}
