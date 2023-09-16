namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Lion.
/// </summary>
public interface ILion : IMammal
{
    #region Interface Members
    /// <summary>
    /// subspecies of predators
    /// </summary>
    bool ApexPredator { get; set; }
    bool Packhunter {get; set;}
    /// <summary>
    /// Mane of lion.
    /// </summary>
    string Mane {get; set;}
    bool RoaringCommunication {get; set;}
    bool TerritoryDefense {get; set;}



    #endregion // Interface Members
}
