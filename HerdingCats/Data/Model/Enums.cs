namespace HerdingCats.Data.Model
{

    public enum CatAreas
    {
        OwnRoom,
        OwnRoomNight,
        Expanding,
        AllRooms,
        Other
    }

    public enum Touchability
    {
        None,
        UsingScratchingStick,
        UsingHands,
        CanPickUp
    }

    public enum LitterboxHabits
    {
        Uses,
        PeesOutside,
        PoopsOutside
    }

    public enum CanCheck
    {
        Yes,
        Maybe,
        No
    }

}