using System.Globalization;

namespace HerdingCatsTests.Components;

public class InvariantCultureTestContext : TestContext
{
    public InvariantCultureTestContext() => CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
}