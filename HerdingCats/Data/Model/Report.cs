namespace HerdingCats.Data.Model;

public class Report()
{
    public int Id { get; set; }
    public Human Author { get; set; } = new();
    public DateTime Date { get; set; }
    public byte SafeScore { get; set; }
    public CatAreas? Areas { get; set; }
    public string? CatAreasOther { get; set; }
    public Touchability? TouchTolerance { get; set; }
    public bool StaysNear { get; set; }
    public bool SeeksContact { get; set; }
    public bool TrustsKnownPeople { get; set; }
    public bool TrustsNewPeople { get; set; }
    public string FeedingComments { get; set; } = "";
    public LitterboxHabits? Litterbox { get; set; }
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
    public string? OverallEvaluation { get; set; }
    public string? GuidanceEvaluation { get; set; }
    public string? HandleScaredCats { get; set; }
    public string? ImprovementSuggestions { get; set; }
    public string? Comments { get; set; }
}