using System;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Base;
using MsBox.Avalonia.Enums;

namespace PALC.Common.Views.Templates;

public static class MessageBoxTools
{
    public static IMsBox<ButtonResult> CreateErrorMsgBox(string message, Exception? ex = null)
        => MessageBoxManager.GetMessageBoxStandard(
            "Error!",
            message + "\n\n" + (ex?.Message ?? string.Empty)
        );

    public static ProgressModalDialog CreateProgressModalDialog(string content)
        => new ProgressModalDialog(content);
}
