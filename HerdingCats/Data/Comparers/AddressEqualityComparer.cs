using System.Diagnostics.CodeAnalysis;

using HerdingCats.Data.Model;

namespace HerdingCats.Data.Comparers;

public class AddressEqualityComparer : IEqualityComparer<Address>
{
    public bool Equals(Address? x, Address? y) =>
        x is Address lhs &&
        y is Address rhs &&
        lhs.Street == rhs.Street &&
        lhs.City == rhs.City &&
        lhs.PostalCode == rhs.PostalCode;
    public int GetHashCode([DisallowNull] Address obj) => HashCode.Combine(obj.Street, obj.City, obj.PostalCode);
}