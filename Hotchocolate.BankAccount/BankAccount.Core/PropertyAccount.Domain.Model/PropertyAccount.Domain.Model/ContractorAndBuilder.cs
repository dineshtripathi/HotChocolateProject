namespace PropertyAccount.Domain.Model;

public class ContractorAndBuilder
{
    public int Id { get; set; }
    public string ContractorBuilderName { get; set; }
    public int NoOfHouseAllocated { get; set; }
    public bool IsSubcontractor { get; set; }
    public DateTime DateOfContract { get; set; }
    public string AgreementNumber { get; set; }
    public int CompanyRegistrationNumber { get; set; }
    public int PropertyId { get; set; }
    public Property Property { get; set; }
}