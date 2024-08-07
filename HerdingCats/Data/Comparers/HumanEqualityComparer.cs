using System.Diagnostics.CodeAnalysis;

using HerdingCats.Data.Model;

namespace HerdingCats.Data.Comparers;

class HumanEqualityComparer : IEqualityComparer<Human>
{
    private AddressEqualityComparer addressEqualityComparer = new();

    public bool Equals(Human? x, Human? y) =>
        x is Human lhs &&
        y is Human rhs &&
        lhs.FirstName == rhs.FirstName &&
        lhs.LastName == rhs.LastName &&
        addressEqualityComparer.Equals(lhs.Address, rhs.Address);
        
    public int GetHashCode([DisallowNull] Human obj) => HashCode.Combine(obj.FirstName, obj.LastName);
}