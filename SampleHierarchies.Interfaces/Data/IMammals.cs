using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Interfaces.Data;

/// <summary>
/// Mammals collection.
/// </summary>
public interface IMammals
{
    #region Interface Members

    /// <summary>
    /// Dogs collection.
    /// </summary>
    List<IDog> Dogs { get; set; }
    /// <summary>
    /// Lions collection.
    /// </summary>
    List<ILion> Lions { get; set; }
    /// <summary>
    /// Elephants collection.
    /// </summary>
    List<IElephant> Elephants { get; set; }
    /// <summary>
    /// Polarbears collection
    /// </summary>
    List<IPolarbear> Polarbears { get; set; }

    #endregion // Interface Members
}
