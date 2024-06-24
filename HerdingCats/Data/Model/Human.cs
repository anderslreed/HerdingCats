namespace HerdingCats.Data.Model
{

public class Human
{
    public uint Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public Address PrimaryAddress { get; set; } = new();
}

}