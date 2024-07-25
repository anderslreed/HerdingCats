namespace HerdingCats.Data.Model;

public class Address
{
    public int Id { get; set; }
    public string Street { get; set; } = "";
    public string City { get; set; } = "";
    public ushort PostCode { get; set; }

    public override bool Equals(object? obj) =>
        obj is Address other &&
        Street == other.Street &&
        City == other.City &&
        PostCode == other.PostCode;

    public override int GetHashCode() => HashCode.Combine(Street, City, PostCode);

    public static bool operator ==(Address lhs, Address rhs) => lhs.Equals(rhs);
    public static bool operator !=(Address lhs, Address rhs) => !lhs.Equals(rhs);
}