namespace HerdingCats.Data.Model;

public class Human
{
    public int Id { get; set; }
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";

    public override bool Equals(object? obj) =>
        obj is Human other &&
        FirstName == other.FirstName &&
        LastName == other.LastName;

    public override int GetHashCode() => HashCode.Combine(FirstName, LastName);

    public static bool operator ==(Human lhs, Human rhs) => lhs.Equals(rhs);
    public static bool operator !=(Human lhs, Human rhs) => !lhs.Equals(rhs);
}
