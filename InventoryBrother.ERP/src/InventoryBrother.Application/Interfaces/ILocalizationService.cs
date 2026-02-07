using System.ComponentModel;

namespace InventoryBrother.Application.Interfaces;

public interface ILocalizationService : INotifyPropertyChanged
{
    string Translate(string key);
    void SetLanguage(string languageCode);
    string CurrentLanguage { get; }
    bool IsRightToLeft { get; }
    
    // Indexer for simpler XAML binding if needed
    string this[string key] { get; }
}
