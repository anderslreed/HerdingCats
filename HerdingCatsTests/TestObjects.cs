using HerdingCats.Data.Model;

namespace HerdingCatsTests;

public static class TestObjects
{
    public static List<Human> GetHumans() =>
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

    public static List<Cat> GetCats() =>
    [
        new()
        {
            Name = "InTheHat",
            IntakeDate = new DateTime(2000, 1, 2)
        },
        new()
        {
            Name = "InBoots",
            IntakeDate = new DateTime(2000, 2, 3)
        },
        new()
        {
            Name = "Garfield",
            IntakeDate = new DateTime(2000, 4, 5)
        }
    ];

    public static List<Address> GetAddresses()
    {
        List<Address> addresses = [
            new Address()
            {
                Street="221B Baker St",
                City="London",
                PostCode=1111
            },
            new Address()
            {
                Street="742 Evergreen Terrace",
                City="Springfield",
                PostCode=2222
            }
        ];

        var humans = GetHumans();
        var cats = GetCats();

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

        addresses[0].Cats.Add(cats[0]);
        addresses[1].Cats.Add(cats[1]);
        addresses[1].Cats.Add(cats[2]);

        addresses[0].Humans.Add(humans[0]);
        addresses[1].Humans.Add(humans[1]);

        return addresses;
    }
}