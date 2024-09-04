using Microsoft.AspNetCore.Identity;

namespace HerdingCats.Data.Model;

public class Human : IdentityUser<int>
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public Address Address { get; set; } = new();
}