using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace PALC.Common.Views.Templates;


public class Browse : TemplatedControl {
    public static readonly StyledProperty<string> WatermarkProperty =
            AvaloniaProperty.Register<Browse, string>(nameof(Watermark), "");

    public string Watermark
    {
        get => GetValue(WatermarkProperty);
        set => SetValue(WatermarkProperty, value);
    }


    public static readonly StyledProperty<string?> DisplayProperty =
        AvaloniaProperty.Register<Browse, string?>(nameof(Display), null);

    public string? Display
    {
        get => GetValue(DisplayProperty);
        set => SetValue(DisplayProperty, value);
    }


    public static readonly StyledProperty<string> LabelTextProperty =
        AvaloniaProperty.Register<Browse, string>(nameof(LabelText));

    public string LabelText
    {
        get => GetValue(LabelTextProperty);
        set => SetValue(LabelTextProperty, value);
    }


    public static readonly StyledProperty<AsyncRelayCommand> ButtonClickProperty =
        AvaloniaProperty.Register<Browse, AsyncRelayCommand>(nameof(ButtonClick), new AsyncRelayCommand(async () => { await Task.FromResult(0); }));

    public AsyncRelayCommand ButtonClick
    {
        get => GetValue(ButtonClickProperty);
        set => SetValue(ButtonClickProperty, value);
    }
}



public class BrowseTools
{
    public static async Task<IReadOnlyList<IStorageFolder>> OpenFolder(Visual topLevelFrom, string title)
    {
        TopLevel topLevel = TopLevel.GetTopLevel(topLevelFrom) ?? throw new Exception("Toplevel is missing.");
        IReadOnlyList<IStorageFolder> folders = await topLevel.StorageProvider.OpenFolderPickerAsync(
            new FolderPickerOpenOptions { Title = title }
        );

        return folders;
    }
}