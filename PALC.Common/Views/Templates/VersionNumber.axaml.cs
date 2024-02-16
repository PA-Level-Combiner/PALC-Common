using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Semver;
using System;
using System.ComponentModel;
using System.Globalization;

namespace PALC.Common.Views.Templates;

public class VersionNumber : TemplatedControl
{
    public static SemVersion DesignRel => SemVersion.Parse("5.6.73", SemVersionStyles.Any);
    public static SemVersion DesignPre => SemVersion.Parse("5.6.73-zeta.1", SemVersionStyles.Any);


    public static readonly StyledProperty<SemVersion> VerProperty =
        AvaloniaProperty.Register<VersionNumber, SemVersion>(nameof(Ver),
            SemVersion.Parse("5.6.73-alpha.1", SemVersionStyles.Any)
        );

    public SemVersion Ver
    {
        get => GetValue(VerProperty);
        set => SetValue(VerProperty, value);
    }
}

public class VerMainConverter : IValueConverter
{
    public static readonly VerMainConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is SemVersion ver)
            return $"{ver.Major}.{ver.Minor}.{ver.Patch}";

        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}

public class VerPrereleaseConverter : IValueConverter
{
    public static readonly VerPrereleaseConverter Instance = new();

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is SemVersion ver)
        {
            if (ver.IsPrerelease) return ver.Prerelease;
            else return null;
        }

        return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
