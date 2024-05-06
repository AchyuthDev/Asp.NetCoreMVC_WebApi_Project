﻿using System.ComponentModel.DataAnnotations;

namespace RestuarentComplent.API.Models.DomineModels
{
    public class CustomerTbModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DayTimePhoneNo { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddressLine2 { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string EmailId { get; set; }
        public string ExplanationDateInEstablistment { get; set; }

        public int CountryId { get; set; }

        public virtual CountyTbModel Country { get; set; }

        public int CityId { get; set; }

        public virtual CityTbModel City { get; set; }

        public bool IsActive { get; set; } = true;  
    }
}
