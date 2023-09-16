using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic Lion class.
/// </summary>
    public class Lion : MammalBase, ILion
{
   
    #region Public Methods

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"\nName:{Name} \nAge: {Age} \nMane: {Mane} \nApex Predator: {ApexPredator} \nPackHunter: {Packhunter} " +
            $"\nRoaring Communication: {RoaringCommunication} \nTerritory Deffense: {TerritoryDefense}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is ILion ad)
        {
            base.Copy(animal);
            Mane = ad.Mane;
            ApexPredator = ad.ApexPredator;
            Packhunter  = ad.Packhunter;
            RoaringCommunication = ad.RoaringCommunication;
            TerritoryDefense = ad.TerritoryDefense;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties
    /// <inheritdoc/>
    public string Mane { get; set; }
    /// <inheritdoc/>
    public bool ApexPredator { get; set; }
    /// <inheritdoc/>
    public bool Packhunter { get; set; }
    /// <inheritdoc/>
    public bool RoaringCommunication { get; set; }
    /// <inheritdoc/>
    public bool TerritoryDefense { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="age">Age</param>
    /// <param name="name">Name</param>
    /// <param name="mane">Mane</param>
    public Lion(string name, string mane, int age, bool apexPredator, bool packhunter, bool roaringCommunication, bool territoryDefense) : base(name, age, MammalSpecies.Lion)
    {
        Mane = mane;
        ApexPredator = apexPredator;
        Packhunter = packhunter;
        RoaringCommunication = roaringCommunication;
        TerritoryDefense = territoryDefense;
    }
    #endregion // Ctors And Properties
}

