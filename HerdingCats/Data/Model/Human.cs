namespace HerdingCats.Data.Model;

public class Human
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public Address Address { get; set; } = new();
}