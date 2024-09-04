using System.Diagnostics.CodeAnalysis;

using HerdingCats.Data.Model;

namespace HerdingCats.Data.Comparers;

public class CatEqualityComparer : IEqualityComparer<Cat>
{
    private AddressEqualityComparer addressEqualityComparer = new();

    public bool Equals(Cat? x, Cat? y) =>
        x is Cat lhs &&
        y is Cat rhs &&
        lhs.Name == rhs.Name &&
        lhs.IntakeDate == rhs.IntakeDate &&
        (
           lhs.Address == null && rhs.Address == null ||
           addressEqualityComparer.Equals(lhs.Address, rhs.Address)
        );

    public int GetHashCode([DisallowNull] Cat obj) => HashCode.Combine(obj.SecondaryId, obj.Name, obj.IntakeDate);
}