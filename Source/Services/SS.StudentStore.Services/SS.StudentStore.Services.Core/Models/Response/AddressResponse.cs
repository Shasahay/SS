using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Models.Response
{
    public class AddressResponse
    {
        public long? AddressId { get; set; }
        public long? UserId { get; set; }
        public int? AddressTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HouseNumber { get; set; }
        public string Apartment { get; set; }
        public string Street { get; set; }
        public string Colony { get; set; }
        public string Locality { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string Country { get; set; }
        public string FullAddress { get; set; }
        public string LandMark { get; set; }
        public bool? IsActive { get; set; }
    }
}
