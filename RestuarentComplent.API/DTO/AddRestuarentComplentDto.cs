using RestuarentComplent.API.Models.DomineModels;

namespace RestuarentComplent.API.DTO
{
    public class AddRestuarentComplentDto
    {
        public string EstablishmentName { get; set; }
        public string EstablishmentStreetAddress { get; set; }
        public string EstablishmentStreetAddressLine2 { get; set; }
        public string EstablishmentRegion { get; set; }
        public string EstablishmentPostalCode { get; set; }
        public int EstablishmentCountry { get; set; }
        public int EstablishmentCity { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string DaytimePhone { get; set; }
        public string CustomerStreetAddress { get; set; }
        public string CustomerStreetAddressLine2 { get; set; }
        public string CustomerRegion { get; set; }
        public string CustomerPostalCode { get; set; }
        public string Email { get; set; }
        public string TextAreaExplain { get; set; }
        public int CustomerCountry { get; set; }
        public int CustomerCity { get; set; }
    }
}
