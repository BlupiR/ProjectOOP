using System.Runtime.Intrinsics.X86;

namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Polarbear.
/// </summary>
public interface IPolarbear : IMammal
{
    #region Interface Members
    /// <summary>
    /// Thick fur coat
    /// </summary>
    string Thickfurcoat { get; set; }
    /// <summary>
    /// Large paws 
    /// </summary>
    string Largepaws { get; set; }
    /// <summary>
    /// Carnivorous diet 
    /// </summary>
    string Carnivorousdiet { get; set; }
    /// <summary>
    /// Excellent sense of smell
    /// <summary>
    string Excellentsenseofsmell { get; set; }
    /// <summary>
    /// Semi-aquatic 
    /// <summary>   
    bool Semiaquatic { get; set; }

    #endregion // Interface Members
}
