using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System.Windows.Input;

namespace PALC.Common.Views.Templates;


public partial class LevelList : TemplatedControl
{
    public static readonly StyledProperty<object> ListBoxProperty =
        AvaloniaProperty.Register<LevelList, object>(nameof(ListBox));
    public object ListBox
    {
        get => GetValue(ListBoxProperty);
        set => SetValue(ListBoxProperty, value);
    }



    public static readonly StyledProperty<bool> AddItemEnabledProperty =
        AvaloniaProperty.Register<LevelList, bool>(nameof(AddItemEnabled), true);
    public bool AddItemEnabled
    {
        get => GetValue(AddItemEnabledProperty);
        set => SetValue(AddItemEnabledProperty, value);
    }


    public static readonly StyledProperty<ICommand> AddItemCommandProperty =
        AvaloniaProperty.Register<LevelList, ICommand>(nameof(AddItemCommand));
    public ICommand AddItemCommand
    {
        get => GetValue(AddItemCommandProperty);
        set => SetValue(AddItemCommandProperty, value);
    }


    public static readonly StyledProperty<bool> DeleteItemEnabledProperty =
        AvaloniaProperty.Register<LevelList, bool>(nameof(DeleteItemEnabled), true);
    public bool DeleteItemEnabled
    {
        get => GetValue(DeleteItemEnabledProperty);
        set => SetValue(DeleteItemEnabledProperty, value);
    }


    public static readonly StyledProperty<ICommand> DeleteItemCommandProperty =
        AvaloniaProperty.Register<LevelList, ICommand>(nameof(DeleteItemCommand));
    public ICommand DeleteItemCommand
    {
        get => GetValue(DeleteItemCommandProperty);
        set => SetValue(DeleteItemCommandProperty, value);
    }
}
