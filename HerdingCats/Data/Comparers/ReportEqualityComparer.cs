using System.Diagnostics.CodeAnalysis;

using HerdingCats.Data.Model;

namespace HerdingCats.Data.Comparers;

class ReportEqualityComparer : IEqualityComparer<Report>
{
    private HumanEqualityComparer humanEqualityComparer = new();

    public bool Equals(Report? x, Report? y) =>
        x is Report lhs &&
        y is Report rhs &&
        humanEqualityComparer.Equals(lhs.Author, rhs.Author) &&
        lhs.Date == rhs.Date &&
        lhs.SafeScore == rhs.SafeScore &&
        lhs.Areas == rhs.Areas &&
        lhs.CatAreasOther == rhs.CatAreasOther &&
        lhs.TouchTolerance == rhs.TouchTolerance &&
        lhs.StaysNear == rhs.StaysNear &&
        lhs.SeeksContact == rhs.SeeksContact &&
        lhs.TrustsKnownPeople == rhs.TrustsKnownPeople &&
        lhs.TrustsNewPeople == rhs.TrustsNewPeople &&
        lhs.FeedingComments == rhs.FeedingComments &&
        lhs.Litterbox == rhs.Litterbox &&
        lhs.DigestiveIssues == rhs.DigestiveIssues &&
        lhs.CanCheckPaws == rhs.CanCheckPaws &&
        lhs.CanCheckEars == rhs.CanCheckEars &&
        lhs.CanCheckTeeth == rhs.CanCheckTeeth &&
        lhs.ReactsToSound == rhs.ReactsToSound &&
        lhs.ReactsToNewPeople == rhs.ReactsToNewPeople &&
        lhs.ReactsToMovement == rhs.ReactsToMovement &&
        lhs.ReactsToOther == rhs.ReactsToOther &&
        lhs.Developments == rhs.Developments &&
        lhs.Description == rhs.Description &&
        lhs.PhotographerConsent == rhs.PhotographerConsent &&
        lhs.OverallEvaluation == rhs.OverallEvaluation &&
        lhs.GuidanceEvaluation == rhs.GuidanceEvaluation &&
        lhs.HandleScaredCats == rhs.HandleScaredCats &&
        lhs.ImprovementSuggestions == rhs.ImprovementSuggestions &&
        lhs.Comments == rhs.Comments;

    public int GetHashCode([DisallowNull] Report obj)
    {
        HashCode hashCode = new();
        hashCode.Add(obj.Author);
        hashCode.Add(obj.Date);
        hashCode.Add(obj.SafeScore);
        hashCode.Add(obj.Areas);
        hashCode.Add(obj.CatAreasOther);
        hashCode.Add(obj.TouchTolerance);
        hashCode.Add(obj.StaysNear);
        hashCode.Add(obj.SeeksContact);
        hashCode.Add(obj.TrustsKnownPeople);
        hashCode.Add(obj.TrustsNewPeople);
        hashCode.Add(obj.FeedingComments);
        hashCode.Add(obj.Litterbox);
        hashCode.Add(obj.DigestiveIssues);
        hashCode.Add(obj.CanCheckPaws);
        hashCode.Add(obj.CanCheckEars);
        hashCode.Add(obj.CanCheckTeeth);
        hashCode.Add(obj.ReactsToSound);
        hashCode.Add(obj.ReactsToMovement);
        hashCode.Add(obj.ReactsToOther);
        hashCode.Add(obj.Developments);
        hashCode.Add(obj.Description);
        hashCode.Add(obj.PhotographerConsent);
        hashCode.Add(obj.OverallEvaluation);
        hashCode.Add(obj.GuidanceEvaluation);
        hashCode.Add(obj.HandleScaredCats);
        hashCode.Add(obj.ImprovementSuggestions);
        hashCode.Add(obj.Comments);
        return hashCode.ToHashCode();
    }
}