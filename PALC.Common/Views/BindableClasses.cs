using Avalonia.Controls;
using Avalonia.Data;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls.Primitives;

namespace PALC.Common.Views;



// This is used to make classes bindable, eg. {Binding someString}
// Taken from https://github.com/AvaloniaUI/Avalonia/issues/2427#issuecomment-1210469405
public class BindableClasses
{
    static BindableClasses()
    {
        ClassesProperty.Changed.Subscribe(x => HandleClassesChanged(x.Sender, x.NewValue.GetValueOrDefault<string>()));
    }

    public static readonly AttachedProperty<string> ClassesProperty = AvaloniaProperty.RegisterAttached<BindableClasses, StyledElement, string>(
        "Classes", "", false, BindingMode.OneTime);


    private static void HandleClassesChanged(AvaloniaObject element, string? classes)
    {
        if (element is StyledElement styled)
        {
            foreach (var cls in Classes.Parse(classes ?? ""))
                styled.Classes.Add(cls);
        }
    }

    public static void SetClasses(AvaloniaObject element, object? commandValue)
    {
        element.SetValue(ClassesProperty, commandValue);
    }


    public static string GetClasses(AvaloniaObject element)
    {
        return element.GetValue(ClassesProperty);
    }
}
