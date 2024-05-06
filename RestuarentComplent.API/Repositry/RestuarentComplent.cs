using RestuarentComplent.API.Data;
using RestuarentComplent.API.DTO;
using RestuarentComplent.API.Models.DomineModels;
using System.Collections.Generic;
namespace RestuarentComplent.API.Repositry
{
    public class RestuarentComplentRepositry : IRestaurentComplent
    {
        private readonly ApplicationDbContext _context;

        public RestuarentComplentRepositry(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AddRestuarentComplentDto> AddRestuarentComplent(AddRestuarentComplentDto Details)
        {
            try
            {
                CustomerTbModel Customer = new CustomerTbModel
                {
                    FirstName = Details.CustomerFirstName,
                    LastName = Details.CustomerLastName,
                    EmailId = Details.Email,
                    PostalCode = Details.CustomerPostalCode,
                    CountryId = Details.CustomerCountry,
                    CityId = Details.CustomerCity,
                    DayTimePhoneNo = Details.DaytimePhone,
                    Region = Details.CustomerRegion,
                    ExplanationDateInEstablistment = Details.TextAreaExplain,
                    StreetAddress = Details.CustomerStreetAddress,
                    StreetAddressLine2 = Details.CustomerStreetAddressLine2
                };
                EstablismentTbModel establisment = new EstablismentTbModel
                {
                    EstablishmentName = Details.EstablishmentName,
                    StreetAddress = Details.EstablishmentStreetAddress,
                    StreetAddressLine2 = Details.EstablishmentStreetAddressLine2,
                    CountryId = Details.EstablishmentCountry,
                    CityId = Details.EstablishmentCity,
                    PostalCode = Details.EstablishmentPostalCode,
                    Region = Details.EstablishmentRegion
                };
                await _context.CustomerTb.AddAsync(Customer);
                var CustomerSuccess = await _context.SaveChangesAsync();
                await _context.EstablismentTb.AddAsync(establisment);
                var EstablishmentSuccuss = _context.SaveChangesAsync();
                if (CustomerSuccess != 0)
                {
                    return Details;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<GetAllComplentDto> GetAllComplents()
        {
            try
            {
                List<GetAllComplentDto> AllDetails = new List<GetAllComplentDto>();
                var Details = from customer in _context.CustomerTb
                              join establisment in _context.EstablismentTb on customer.Id equals establisment.Id
                              where establisment.IsActive== true
                              select new GetAllComplentDto
                              {
                                  EstablishmentName = establisment.EstablishmentName,
                                  EstablishmentStreetAddress = establisment.StreetAddress,
                                  EstablishmentStreetAddressLine2 = establisment.StreetAddressLine2,
                                  EstablishmentRegion = establisment.Region,
                                  EstablishmentPostalCode = establisment.PostalCode,
                                  EstablishmentCountry = establisment.CountryId,
                                  EstablishmentCity = establisment.CityId,
                                  CustomerFirstName = customer.FirstName,
                                  CustomerLastName = customer.LastName,
                                  DaytimePhone = customer.DayTimePhoneNo,
                                  CustomerStreetAddress = customer.StreetAddress,
                                  CustomerStreetAddressLine2 = customer.StreetAddressLine2,
                                  CustomerRegion = customer.Region,
                                  CustomerPostalCode = customer.PostalCode,
                                  CustomerCountry = customer.CountryId,
                                  CustomerCity = customer.CityId,
                                  TextAreaExplain = customer.ExplanationDateInEstablistment,
                                  Email = customer.EmailId,
                                  Id = establisment.Id,


                              };

                foreach (var item in Details)
                {
                    AllDetails.Add(item);
                }
                return AllDetails;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public GetAllComplentDto GetRestuarentComplent(int id)
        {
            try
            {
                var Detail = from customer in _context.CustomerTb
                             join establisment in _context.EstablismentTb on customer.Id equals establisment.Id
                             where customer.Id == id
                             select new GetAllComplentDto
                             {
                                 EstablishmentName = establisment.EstablishmentName,
                                 EstablishmentStreetAddress = establisment.StreetAddress,
                                 EstablishmentStreetAddressLine2 = establisment.StreetAddressLine2,
                                 EstablishmentRegion = establisment.Region,
                                 EstablishmentPostalCode = establisment.PostalCode,
                                 EstablishmentCountry = establisment.CountryId,
                                 EstablishmentCity = establisment.CityId,
                                 CustomerFirstName = customer.FirstName,
                                 CustomerLastName = customer.LastName,
                                 DaytimePhone = customer.DayTimePhoneNo,
                                 CustomerStreetAddress = customer.StreetAddress,
                                 CustomerStreetAddressLine2 = customer.StreetAddressLine2,
                                 CustomerRegion = customer.Region,
                                 CustomerPostalCode = customer.PostalCode,
                                 CustomerCountry = customer.CountryId,
                                 CustomerCity = customer.CityId,
                                 TextAreaExplain = customer.ExplanationDateInEstablistment,
                                 Email = customer.EmailId,
                                 Id = establisment.Id,
                             };
                Detail.First();
                GetAllComplentDto ComplentDetail = Detail.First();
                return ComplentDetail;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public GetAllComplentDto UpdateRestuarentComplent(GetAllComplentDto UpdatedComplentData)
        {
            try
            {
                var CustomerExistingComplent = _context.CustomerTb.Where(e => e.Id == UpdatedComplentData.Id).First();
                var EstablishmentExistingComplent = _context.EstablismentTb.Where(e => e.Id == UpdatedComplentData.Id).First();

                //update the customer data into datbase 
                CustomerExistingComplent.FirstName = UpdatedComplentData.CustomerFirstName;
                CustomerExistingComplent.LastName = UpdatedComplentData.CustomerLastName;
                CustomerExistingComplent.StreetAddress = UpdatedComplentData.CustomerStreetAddress;
                CustomerExistingComplent.StreetAddressLine2 = UpdatedComplentData.CustomerStreetAddressLine2;
                CustomerExistingComplent.PostalCode = UpdatedComplentData.CustomerPostalCode;
                CustomerExistingComplent.CityId = UpdatedComplentData.CustomerCity;
                CustomerExistingComplent.CountryId = UpdatedComplentData.CustomerCountry;
                CustomerExistingComplent.EmailId = UpdatedComplentData.Email;
                CustomerExistingComplent.DayTimePhoneNo = UpdatedComplentData.DaytimePhone;
                CustomerExistingComplent.ExplanationDateInEstablistment = UpdatedComplentData.TextAreaExplain;
                CustomerExistingComplent.Region = UpdatedComplentData.CustomerRegion;

                //update the Establishment table data in database 
                EstablishmentExistingComplent.StreetAddress = UpdatedComplentData.EstablishmentStreetAddress;
                EstablishmentExistingComplent.StreetAddressLine2 = UpdatedComplentData.EstablishmentStreetAddressLine2;
                EstablishmentExistingComplent.CityId = UpdatedComplentData.EstablishmentCity;
                EstablishmentExistingComplent.CountryId = UpdatedComplentData.EstablishmentCountry;
                EstablishmentExistingComplent.Region = UpdatedComplentData.EstablishmentRegion;
                EstablishmentExistingComplent.EstablishmentName = UpdatedComplentData.EstablishmentName;
                EstablishmentExistingComplent.PostalCode = UpdatedComplentData.EstablishmentPostalCode;

                //save the data into database
                _context.SaveChanges();
                return UpdatedComplentData;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void DeleteRestuarentComplent(int id)
        {
            try
            {
                var CustomerDeleteComplent = _context.CustomerTb.Where(e => e.Id == id).First();
                var EstablishmentDeleteComplent = _context.EstablismentTb.Where(e => e.Id == id).First();
                CustomerDeleteComplent.IsActive = false;
                EstablishmentDeleteComplent.IsActive = false;
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public GetCityCountryNames GetCountryNameAndCityName(int id)
        {
            try
            {
                var EstablismentCountryCityIds = _context.EstablismentTb.Find(id);
                var CustomerCountryCityIds = _context.CustomerTb.Find(id);

                var EsCountryNameAndCityName = (from Establishment in _context.EstablismentTb
                                                join Country in _context.CountryTb
                                             on Establishment.CountryId equals Country.CountryId
                                                join City in _context.CityTb on
                                             Country.CountryId equals City.CountryId
                                                where Establishment.Id == id && City.CityId == EstablismentCountryCityIds.CityId
                                                select new { CountryName = Country.CountryName, Cityname = City.CityName }).FirstOrDefault();

                var CusCountryNameAndCityName = (from Customer in _context.CustomerTb
                                                 join Country in _context.CountryTb
                                              on Customer.CountryId equals Country.CountryId
                                                 join City in _context.CityTb on
                                              Country.CountryId equals City.CountryId
                                                 where Customer.Id == id && City.CityId == CustomerCountryCityIds.CityId
                                                 select new { CountryName = Country.CountryName, Cityname = City.CityName }).FirstOrDefault();


                GetCityCountryNames obj = new GetCityCountryNames();
                obj.CustomerCityName = CusCountryNameAndCityName.Cityname;
                obj.CustomerCountryName = CusCountryNameAndCityName.CountryName;
                obj.EstablishmentCityName = EsCountryNameAndCityName.Cityname;
                obj.EstablishmentCountryName = EsCountryNameAndCityName.CountryName;
                return obj;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<GetCitys> GetCitys(int countryid)
        {
            var Citys = (from City in _context.CityTb where City.CountryId == countryid select new { CityName = City.CityName }).ToList();
            List<GetCitys> obj=new List<GetCitys>();
            return obj;
        }
         
        public int DeleteComplent(int id)
        {
            var EstablishmentDelete = _context.EstablismentTb.Find(id);
             var CustomerDelete=_context.CustomerTb.Find(id);

            EstablishmentDelete.IsActive=false;
            CustomerDelete.IsActive = false;
          int i=  _context.SaveChanges();
            return i;
        }
    }
}
