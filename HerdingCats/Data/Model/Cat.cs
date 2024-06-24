namespace HerdingCats.Data.Model
{

public class Cat
{
    public uint Id { get; set;}
    public string Name { get; set; } = "";
    public DateTime IntakeDate { get; set; }

    public IList<Report> Reports { get; set; } = [];
}

}