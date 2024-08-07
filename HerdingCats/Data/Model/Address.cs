namespace HerdingCats.Data.Model;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public ushort PostCode { get; set; }
}