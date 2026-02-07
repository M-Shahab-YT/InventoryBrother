using Avalonia;
using Avalonia.Data;
using Avalonia.Markup.Parsers;
using Avalonia.Markup.Xaml;
using InventoryBrother.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace InventoryBrother.Desktop.Extensions;

public class LocalizeExtension : MarkupExtension
{
    public string Key { get; set; }

    public LocalizeExtension(string key)
    {
        Key = key;
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        var app = Avalonia.Application.Current as App;
        var localizationService = app?.Services?.GetService<ILocalizationService>();
        if (localizationService == null) return Key;

        var binding = new Binding
        {
            Source = localizationService,
            Path = $"[{Key}]",
            Mode = BindingMode.OneWay
        };

        return binding;
    }
}
