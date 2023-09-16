using SampleHierarchies.Interfaces.Data;

namespace SampleHierarchies.Interfaces.Services;

public interface ISettingsService
{

    #region Interface Members

    /// <summary>
    /// Save settings.
    /// </summary>   
    /// <param name="filePath">Json path</param>

    void SaveSettings(ISettings settings, string filePath);
    /// <summary>
    /// Load settings.
    /// </summary>
    /// <param name="filePath">Json path</param>

    ISettings LoadSettings(string filePath);

    void ChangeScreenColor(ISettings settings, string screenName);
    #endregion // Interface Members

}
