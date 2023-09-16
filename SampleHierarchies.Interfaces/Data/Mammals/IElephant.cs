namespace SampleHierarchies.Interfaces.Data.Mammals;

/// <summary>
/// Interface depicting a Elephants.
/// </summary>
public interface IElephant : IMammal
{
    #region Interface Members
    /// <summary>
    /// Height of Elephant
    /// </summary>
    float Height { get; set; }
    /// <summary>
    /// Weight of Elephant
    /// </summary>
    float Weight { get; set; }
    /// <summary>
    /// Tusk of Elephant.
    /// </summary>
    float TuskLenght { get; set; }
    /// <summary>
    /// Elephant Lifespan
    /// <summary>
    int LongLifespan { get; set; }
    /// <summary>
    /// Behavior of Elephant 
    /// <summary>
    string SocialBehavior { get; set; }

    #endregion // Interface Members
}
