namespace HerdingCats.Data.Model;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public ushort PostalCode { get; set; }
    public IList<Cat> Cats { get; set; } = [];
    public IList<Human> Humans { get; set; } = [];
}