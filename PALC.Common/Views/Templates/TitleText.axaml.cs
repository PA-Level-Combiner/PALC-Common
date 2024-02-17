using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Data.Converters;
using Semver;
using System;
using System.ComponentModel;
using System.Globalization;

namespace PALC.Common.Views.Templates;

public class TitleText : TemplatedControl
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

    public static readonly StyledProperty<string> TitleProperty =
        AvaloniaProperty.Register<VersionNumber, string>(nameof(Title));

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
}