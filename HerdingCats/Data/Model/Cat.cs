namespace HerdingCats.Data.Model;

public class Cat
{
    public int Id { get; set; }
    public int SecondaryId { get; set; }
    public string Name { get; set; } = "";
    public DateTime IntakeDate { get; set; }
    public IList<Report> Reports { get; set; } = [];

    public override bool Equals(object? obj) =>
        obj is Cat other &&
        Name == other.Name &&
        IntakeDate == other.IntakeDate;

    public override int GetHashCode() => HashCode.Combine(SecondaryId, Name, IntakeDate);

    public static bool operator ==(Cat lhs, Cat rhs) => lhs.Equals(rhs);
    public static bool operator !=(Cat lhs, Cat rhs) => !lhs.Equals(rhs);
}