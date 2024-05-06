using RestuarentComplent.API.DTO;
using RestuarentComplent.API.Models.DomineModels;

namespace RestuarentComplent.API.Repositry
{
    public interface IRestaurentComplent
    {
        
        Task<AddRestuarentComplentDto> AddRestuarentComplent(AddRestuarentComplentDto Details);
        List<GetAllComplentDto> GetAllComplents();
        GetAllComplentDto GetRestuarentComplent(int id);
        GetAllComplentDto UpdateRestuarentComplent(GetAllComplentDto UpdatedComplentData);
        void DeleteRestuarentComplent(int id);
        GetCityCountryNames GetCountryNameAndCityName(int id);

        IEnumerable<GetCitys> GetCitys(int countryid);

        int DeleteComplent(int id);

        
    }
}
