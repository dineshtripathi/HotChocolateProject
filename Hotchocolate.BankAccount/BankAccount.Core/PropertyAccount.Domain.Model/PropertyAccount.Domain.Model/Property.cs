

namespace PropertyAccount.Domain.Model;

public class Property
{
    public int Id { get; set; }
    public string PropertyType { get; set; }
    public int NumberOfFloors { get; set; }
    public bool IsConstructed { get; set; }
    public DateTime Dateofbuilt { get; set; }
    public string County { get; set; }
    public string Council { get; set; }
    public int Rooms { get; set; }
    public int NoOfGarages { get; set; }
    public ICollection<Address> Addresses { get; set; }
    public ICollection<ContractorAndBuilder> ContractorAndBuilders { get; set; }
}