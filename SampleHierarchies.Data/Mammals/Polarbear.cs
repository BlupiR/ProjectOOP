using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic Polarbear class.
/// </summary>
public class Polarbear : MammalBase, IPolarbear
{

    #region Public Methods

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"\nName:{Name} \nAge: {Age} \nThickfurcoat: {Thickfurcoat} \nLargepaws: {Largepaws} \nCarnivorousdiet: {Carnivorousdiet} " +
            $"\nExcellentsenseofsmell: {Excellentsenseofsmell} \nSemiaquatic: {Semiaquatic}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IPolarbear ad)
        {
            base.Copy(animal);
            Thickfurcoat = ad.Thickfurcoat;
            Largepaws = ad.Largepaws;
            Carnivorousdiet = ad.Carnivorousdiet;
            Excellentsenseofsmell = ad.Excellentsenseofsmell;
            Semiaquatic = ad.Semiaquatic;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties
    /// <inheritdoc/>
    public string Thickfurcoat { get; set; }
    /// <inheritdoc/>
    public string Largepaws { get; set; }
    /// <inheritdoc/>
    public string Carnivorousdiet { get; set; }
    /// <inheritdoc/>
    public string Excellentsenseofsmell { get; set; }
    /// <inheritdoc/>
    public bool Semiaquatic { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param Name="age">Age</param>
    /// <param Name="Name">Name</param>
    /// <param Name="SocialBehavior">SocialBehavior</param>
    public Polarbear(string Name, string thickfurcoat, int age, string largepaws, string carnivorousdiet, string excellentsenseofsmell, bool semiaquatic) : base(Name, age, MammalSpecies.Polarbear)
    {
        Thickfurcoat = thickfurcoat;
        Largepaws = largepaws;
        Carnivorousdiet = carnivorousdiet;
        Excellentsenseofsmell = excellentsenseofsmell;
        Semiaquatic = semiaquatic;
    }
    #endregion // Ctors And Properties
}

