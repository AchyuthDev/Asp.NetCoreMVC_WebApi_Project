using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using RestuarentComplent.API.Data;
using RestuarentComplent.API.DTO;
using RestuarentComplent.API.Models.DomineModels;
using RestuarentComplent.API.Repositry;

namespace RestuarentComplent.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class RestuarentComplentController : ControllerBase
    {
        private readonly IRestaurentComplent _RestuarentComplentRepositry;
        private readonly ApplicationDbContext _context;

        public RestuarentComplentController(IRestaurentComplent restaurentComplent,ApplicationDbContext Context)
        {
            _RestuarentComplentRepositry=restaurentComplent;
            _context = Context;
        }
        [HttpPost]
        [EnableQuery]
        [Route("api/RestuarentComplent/AddComplent")]
        
        public async Task<IActionResult> AddComplent(AddRestuarentComplentDto ComplentDetails)
        {
            try
            {
                AddRestuarentComplentDto AddDetails = await _RestuarentComplentRepositry.AddRestuarentComplent(ComplentDetails);
                return Ok(AddDetails);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet]
        [EnableQuery] 
        [Route("api/RestuarentComplent/EstablismentTb")]
        public async Task<IActionResult> GetAllComplentsDetails()
        {
            try
            {
                List<GetAllComplentDto> ComplentLists = _RestuarentComplentRepositry.GetAllComplents();

                return Ok(ComplentLists);
            } 
            catch (Exception)
            {

                return StatusCode(500);
            }
        }

        [HttpGet]
        [EnableQuery]
        [Route("api/RestuarentComplent/GetComplent")]
        public async Task<IActionResult> GetRestuarentComplent(int id)
        {
            try
            {
                GetAllComplentDto detail = _RestuarentComplentRepositry.GetRestuarentComplent(id);
                return Ok(detail);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error check database code id is there or not check in database");
            }
        }
        [HttpPost]
        [EnableQuery]
        [Route("api/RestuarentComplent/UpdateComplent")]
        public async Task<IActionResult> UpdateRestuarentComplent(GetAllComplentDto UpdatedComplentData)
        {
            try
            {
                var UpdatedData = _RestuarentComplentRepositry.UpdateRestuarentComplent(UpdatedComplentData);
                return Ok(UpdatedData);
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal Server Error check Database Co de");
            }
        }
        [HttpPost]
        [EnableQuery]
        [Route("api/RestuarentComplent/DeleteComplent")]
        public async Task<IActionResult> DeleteRestuarentComplent(int id)
        {
           int result= _RestuarentComplentRepositry.DeleteComplent(id);
            return Ok(result);
        }

        [HttpGet]
        [EnableQuery]
        [Route("api/RestuarentComplent/GetCityCountryNames")]

        public async Task<IActionResult> GetCityCountryNames(int id)
        {
           GetCityCountryNames obj=  _RestuarentComplentRepositry.GetCountryNameAndCityName(id);
            return Ok(obj);
        }

        [HttpGet]
        [EnableQuery]
        [Route("api/RestuarentComplent/GetCityNames")]
        public async Task<IActionResult> GetCitys(int Countryid)
        {
            var Citys = (from City in _context.CityTb where City.CountryId == Countryid select new { CityName = City.CityName }).ToList();
            return Ok(Citys);
        }
    }
}
