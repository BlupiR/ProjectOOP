using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Mammals collection.
/// </summary>
public class Mammals : IMammals
{
    #region IMammals Implementation

    /// <inheritdoc/>
    public List<IDog> Dogs { get; set; }
    /// <inheritdoc/>
    public List<ILion> Lions { get; set; }
    /// <inheritdoc/>
    public List<IElephant> Elephants { get; set; }
    ///<inheritdoc/>
    public List<IPolarbear> Polarbears { get; set; }

    #endregion // IMammals Implementation


    #region Ctors

    /// <summary>
    /// Default ctor.
    /// </summary>
    public Mammals()
    {
        Dogs = new List<IDog>();
        Lions = new List<ILion>();
        Elephants = new List<IElephant>();
        Polarbears = new List<IPolarbear>();

    }

    #endregion // Ctors
}
