using SampleHierarchies.Interfaces.Data;
using SampleHierarchies.Interfaces.Data.Mammals;

namespace SampleHierarchies.Data.Mammals;

/// <summary>
/// Very basic Elephant class.
/// </summary>
public class Elephant : MammalBase, IElephant
{

    #region Public Methods

    /// <inheritdoc/>
    public override void Display()
    {
        Console.WriteLine($"\nName:{Name} \nAge: {Age} \nHeight: {Height} \nWeight: {Weight} \nTuskLenght: {TuskLenght} " +
            $"\nLongLifespan: {LongLifespan} \nSocialBehavior: {SocialBehavior}");
    }

    /// <inheritdoc/>
    public override void Copy(IAnimal animal)
    {
        if (animal is IElephant ad)
        {
            base.Copy(animal);
            Height = ad.Height;
            Weight = ad.Weight;
            TuskLenght = ad.TuskLenght;
            LongLifespan = ad.LongLifespan;
            SocialBehavior = ad.SocialBehavior;
        }
    }

    #endregion // Public Methods

    #region Ctors And Properties
    /// <inheritdoc/>
    public float Height { get; set; }
    /// <inheritdoc/>
    public float Weight { get; set; }
    /// <inheritdoc/>
    public float TuskLenght { get; set; }
    /// <inheritdoc/>
    public int LongLifespan { get; set; }
    /// <inheritdoc/>
    public string SocialBehavior { get; set; }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param Name="age">Age</param>
    /// <param Name="Name">Name</param>
    /// <param Name="SocialBehavior">SocialBehavior</param>
    public Elephant(string Name, string socialBehavior, int age, float height, float weight, float tuskLenght, int longLifespan) : base(Name, age, MammalSpecies.Elephant)
    {
        SocialBehavior = socialBehavior;
        Height = height;
        Weight = weight;
        TuskLenght = tuskLenght;
        LongLifespan = longLifespan;
    }
    #endregion // Ctors And Properties
}

