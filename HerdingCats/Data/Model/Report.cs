namespace HerdingCats.Data.Model;

public class Report()
{
    public int Id { get; set; }
    public Human Author { get; set; } = new();
    public DateTime Date { get; set; }
    public byte SafeScore { get; set; }
    public CatAreas Areas { get; set; }
    public string? CatAreasOther { get; set; }
    public Touchability TouchTolerance { get; set; }
    public bool StaysNear { get; set; }
    public bool SeeksContact { get; set; }
    public bool TrustsKnownPeople { get; set; }
    public bool TrustsNewPeople { get; set; }
    public string FeedingComments { get; set; } = "";
    public LitterboxHabits Litterbox { get; set; }
    public bool DigestiveIssues { get; set; }
    public CanCheck CanCheckPaws { get; set; }
    public CanCheck CanCheckEars { get; set; }
    public CanCheck CanCheckTeeth { get; set; }
    public bool ReactsToSound { get; set; } 
    public bool ReactsToNewPeople { get; set; }
    public bool ReactsToMovement { get; set; }
    public string? ReactsToOther { get; set; }
    public string Developments { get; set; } = "";
    public string Description { get; set; } = "";
    public bool PhotographerConsent { get; set; }
    public string? OverallEvaluation { get; set;}
    public string? GuidanceEvaluation { get; set; }
    public string? HandleScaredCats { get; set;}
    public string? ImprovementSuggestions { get; set; }
    public string? Comments { get; set; }

    public override bool Equals(object? obj) =>
        obj is Report other &&
        Author == other.Author &&
        Date == other.Date &&
        SafeScore == other.SafeScore &&
        Areas == other.Areas &&
        CatAreasOther == other.CatAreasOther &&
        TouchTolerance == other.TouchTolerance &&
        StaysNear == other.StaysNear &&
        SeeksContact == other.SeeksContact &&
        TrustsKnownPeople == other.TrustsKnownPeople &&
        TrustsNewPeople == other.TrustsNewPeople &&
        FeedingComments == other.FeedingComments &&
        Litterbox == other.Litterbox &&
        DigestiveIssues == other.DigestiveIssues &&
        CanCheckPaws == other.CanCheckPaws &&
        CanCheckEars == other.CanCheckEars &&
        CanCheckTeeth == other.CanCheckTeeth &&
        ReactsToSound == other.ReactsToSound &&
        ReactsToNewPeople == other.ReactsToNewPeople &&
        ReactsToMovement == other.ReactsToMovement &&
        ReactsToOther == other.ReactsToOther &&
        Developments == other.Developments &&
        Description == other.Description &&
        PhotographerConsent == other.PhotographerConsent &&
        OverallEvaluation == other.OverallEvaluation &&
        GuidanceEvaluation == other.GuidanceEvaluation &&
        HandleScaredCats == other.HandleScaredCats &&
        ImprovementSuggestions == other.ImprovementSuggestions &&
        Comments == other.Comments;

    public override int GetHashCode()
    {
        HashCode hashCode = new();
        hashCode.Add(Author);
        hashCode.Add(Date);
        hashCode.Add(SafeScore);
        hashCode.Add(Areas);
        hashCode.Add(CatAreasOther);
        hashCode.Add(TouchTolerance);
        hashCode.Add(StaysNear);
        hashCode.Add(SeeksContact);
        hashCode.Add(TrustsKnownPeople);
        hashCode.Add(TrustsNewPeople);
        hashCode.Add(FeedingComments);
        hashCode.Add(Litterbox);
        hashCode.Add(DigestiveIssues);
        hashCode.Add(CanCheckPaws);
        hashCode.Add(CanCheckEars);
        hashCode.Add(CanCheckTeeth);
        hashCode.Add(ReactsToSound);
        hashCode.Add(ReactsToMovement);
        hashCode.Add(ReactsToOther);
        hashCode.Add(Developments);
        hashCode.Add(Description);
        hashCode.Add(PhotographerConsent);
        hashCode.Add(OverallEvaluation);
        hashCode.Add(GuidanceEvaluation);
        hashCode.Add(HandleScaredCats);
        hashCode.Add(ImprovementSuggestions);
        hashCode.Add(Comments);
        return hashCode.ToHashCode();
    }

    public static bool operator ==(Report lhs, Report rhs) => lhs.Equals(rhs);
    public static bool operator !=(Report lhs, Report rhs) => !lhs.Equals(rhs);
}
