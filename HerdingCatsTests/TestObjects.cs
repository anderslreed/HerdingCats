using HerdingCats.Data.Model;

namespace HerdingCatsTests;

public class TestObjects
{
    public readonly IList<Address> addresses =
    [
        new Address()
        {
            Street = "221B Baker St",
            City = "London",
            PostalCode = 1111
        },
        new Address()
        {
            Street = "742 Evergreen Terrace",
            City = "Springfield",
            PostalCode = 2222
        }
    ];

    public readonly IList<Human> humans =
    [
        new()
        {
            FirstName = "Arthur",
            LastName = "Dent",
        },
        new()
        {
            FirstName = "Ford",
            LastName = "Prefect",
        }
    ];

    public readonly IList<Cat> cats =
    [
        new()
        {
            Name = "InTheHat",
            IntakeDate = new DateOnly(2000, 1, 2)
        },
        new()
        {
            Name = "InBoots",
            IntakeDate = new DateOnly(2000, 2, 3)
        },
        new()
        {
            Name = "Garfield",
            IntakeDate = new DateOnly(2000, 4, 5)
        }
    ];

    public TestObjects()
    {
        cats[0].Address = addresses[0];
        cats[1].Address = addresses[1];
        cats[2].Address = addresses[1];
        humans[0].Address = addresses[0];
        humans[1].Address = addresses[1];

        AddReports();
    }

    private void AddReports()
    {
        Report report = new()
        {
            Author = humans[0],
            Date = new DateTime(2024, 6, 23),
            SafeScore = 10,
            Areas = CatAreas.OwnRoomNight,
            TouchTolerance = Touchability.UsingScratchingStick,
            StaysNear = true,
            SeeksContact = true,
            TrustsKnownPeople = true,
            TrustsNewPeople = true,
            FeedingComments = "Eats well",
            Litterbox = LitterboxHabits.Uses,
            CanCheckPaws = CanCheck.Yes,
            CanCheckEars = CanCheck.Yes,
            CanCheckTeeth = CanCheck.Yes,
            Description = "Very friendly and playful",
            PhotographerConsent = true
        };
        cats[0].Reports.Add(report);

        report = new()
        {
            Author = humans[1],
            Date = new DateTime(2024, 6, 15),
            SafeScore = 2,
            Areas = CatAreas.OwnRoom,
            TouchTolerance = Touchability.None,
            StaysNear = false,
            SeeksContact = false,
            TrustsKnownPeople = false,
            TrustsNewPeople = false,
            FeedingComments = "Picky eater",
            Litterbox = LitterboxHabits.PeesOutside,
            CanCheckPaws = CanCheck.No,
            CanCheckEars = CanCheck.No,
            CanCheckTeeth = CanCheck.No,
            Description = "Very scared and aggressive",
            PhotographerConsent = false
        };
        cats[1].Reports.Add(report);

        report = new()
        {
            Author = humans[1],
            Date = new(2024, 6, 10),
            SafeScore = 5,
            Areas = CatAreas.AllRooms,
            TouchTolerance = Touchability.CanPickUp,
            StaysNear = true,
            SeeksContact = false,
            TrustsKnownPeople = true,
            TrustsNewPeople = false,
            FeedingComments = "Eats normally",
            Litterbox = LitterboxHabits.Uses,
            CanCheckPaws = CanCheck.Maybe,
            CanCheckEars = CanCheck.Maybe,
            CanCheckTeeth = CanCheck.Maybe,
            Description = "Average behavior",
            PhotographerConsent = true
        };
        cats[2].Reports.Add(report);
    }
}