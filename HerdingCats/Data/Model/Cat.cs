namespace HerdingCats.Data.Model;

public class Cat
{
    public int Id { get; set; }
    public int SecondaryId { get; set; }
    public string Name { get; set; } = "";
    public DateOnly BirthDate { get; set; }
    public Address? Address { get; set; }
    public DateOnly IntakeDate { get; set; }
    public string IntakeComments { get; set; } = "";
    public IList<Report> Reports { get; set; } = [];
}