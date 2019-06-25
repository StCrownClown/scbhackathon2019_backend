namespace hacker2019_bester.Models
{
    public class Address
    {
        public string addressSeqID { get; set; }
        public string usageCode { get; set; }
        public string ownerCode { get; set; }
        public string formatCode { get; set; }
        public string contactIndicator { get; set; }
        public string currentAddressFlag { get; set; }
        public string thaiAddressNumber { get; set; }
        public string thaiAddressVillage { get; set; }
        public string thaiAddressMoo { get; set; }
        public string thaiAddressTrok { get; set; }
        public string thaiAddressSoi { get; set; }
        public string thaiAddressThanon { get; set; }
        public string thaiAddressDistrict { get; set; }
        public string thaiAddressAmphur { get; set; }
        public string thaiAddressProvince { get; set; }
        public string thaiAddressState { get; set; }
        public string engAddressNumber { get; set; }
        public string engAddressVillage { get; set; }
        public string engAddressMoo { get; set; }
        public string engAddressTrok { get; set; }
        public string engAddressSoi { get; set; }
        public string engAddressThanon { get; set; }
        public string engAddressDistrict { get; set; }
        public string engAddressAmphur { get; set; }
        public string engAddressProvince { get; set; }
        public string engAddressState { get; set; }
        public string countryCode { get; set; }
        public string zipCode { get; set; }
        public string floorNumber { get; set; }
        public string unitNumber { get; set; }
        public string lastUpdateUser { get; set; }
    }

    public class Profile
    {
        public string citizenID { get; set; }
        public string passportNumber { get; set; }
        public string alienID { get; set; }
        public string partnerID { get; set; }
        public string thaiFirstName { get; set; }
        public string thaiLastName { get; set; }
        public string engFirstName { get; set; }
        public string engLastName { get; set; }
        public string birthDate { get; set; }
        public string genderCode { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
    }

    public class Customer
    {
        public Profile profile { get; set; }
    }

    public class CustomerResponse : BaseResponse
    {
        public Customer data { get; set; }
    }
}
