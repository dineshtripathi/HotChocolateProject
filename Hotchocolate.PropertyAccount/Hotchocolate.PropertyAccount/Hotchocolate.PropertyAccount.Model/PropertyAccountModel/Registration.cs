public class Registration
{
    public int Id { get; set; }
    public string RegistterdName { get; set; }
    public int NoOfRegistrant { get; set; }
    public bool IsDomesticUse { get; set; }
    public DateTime DateOfRegistration { get; set; }
    public string RegistrationPlace { get; set; }
    public string RegistrationNumber { get; set; }
    public bool IsFreeHold { get; set; }
    public int NoOfYearLease { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
}