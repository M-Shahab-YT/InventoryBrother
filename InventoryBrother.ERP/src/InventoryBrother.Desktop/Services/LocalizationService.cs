using Avalonia.Media;
using Avalonia.Platform;
using InventoryBrother.Application.Interfaces;
using System.Text.Json;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace InventoryBrother.Desktop.Services;

public class LocalizationService : ILocalizationService
{
    private string _currentLanguage = "en";
    private Dictionary<string, string> _translations = new();

    public event PropertyChangedEventHandler? PropertyChanged;

    public string CurrentLanguage => _currentLanguage;

    public bool IsRightToLeft => _currentLanguage == "ps";

    public string this[string key] => Translate(key);

    public LocalizationService()
    {
        LoadLanguage("en");
    }

    public void SetLanguage(string languageCode)
    {
        if (_currentLanguage == languageCode) return;
        
        _currentLanguage = languageCode;
        LoadLanguage(languageCode);
        
        OnPropertyChanged(nameof(CurrentLanguage));
        OnPropertyChanged(nameof(IsRightToLeft));
        
        // Notify all bindings that use the indexer "Item[]" has changed
        OnPropertyChanged("Item[]"); 
    }

    public string Translate(string key)
    {
        if (_translations.TryGetValue(key, out var value))
        {
            return value;
        }
        return key; 
    }

    private void LoadLanguage(string languageCode)
    {
        try
        {
            var uri = new Uri($"avares://InventoryBrother.Desktop/Assets/Localization/{languageCode}.json");
            
            using var stream = AssetLoader.Open(uri);
            using var reader = new StreamReader(stream);
            var json = reader.ReadToEnd();
            _translations = JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading language {languageCode}: {ex.Message}");
            _translations = new();
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
