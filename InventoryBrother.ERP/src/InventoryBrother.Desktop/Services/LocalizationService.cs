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
            _translations = new Dictionary<string, string>();
            
            // Define expected modules for now (safest for AOT/Embedded resources)
            // In a full implementation, we could use AssetLoader.GetAssets if the platform supports it
            var modules = new[] { "common", "pos", "inventory", "dashboard", "hr", "accounting" };
            
            foreach (var module in modules)
            {
                try 
                {
                    var uri = new Uri($"avares://InventoryBrother.Desktop/Assets/Localization/{languageCode}/{module}.json");
                    if (!AssetLoader.Exists(uri)) continue;

                    using var stream = AssetLoader.Open(uri);
                    using var reader = new StreamReader(stream);
                    var json = reader.ReadToEnd();
                    var moduleData = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                    
                    if (moduleData != null)
                    {
                        foreach (var kvp in moduleData)
                        {
                            // If it's common, add directly. Otherwise, prefix with module name.
                            var key = module == "common" ? kvp.Key : $"{module}.{kvp.Key}";
                            _translations[key] = kvp.Value;
                            
                            // Also keep the flat version for backward compatibility where unique
                            if (!_translations.ContainsKey(kvp.Key))
                            {
                                _translations[kvp.Key] = kvp.Value;
                            }
                        }
                    }
                }
                catch { /* Skip missing optional modules */ }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading language {languageCode}: {ex.Message}");
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
