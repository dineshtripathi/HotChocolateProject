public class Address
{
    public int Id { get; set; }
    public string StreetName { get; set; }
    public int HouseNumber { get; set; }
    public bool IsReadyToMove { get; set; }
    public DateTime DateToMove { get; set; }
    public string AreaName { get; set; }
    public string City { get; set; }
    public string PostCode { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
    public ICollection<Registration> Registrations { get; set; }
}