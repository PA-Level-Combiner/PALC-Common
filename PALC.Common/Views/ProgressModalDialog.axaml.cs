using Avalonia.Controls;

using PALC.Common.ViewModels;

namespace PALC.Common.Views;

public partial class ProgressModalDialog : Window
{
    private readonly ProgressModalDialogVM vm;
    public ProgressModalDialog(string content)
    {
        InitializeComponent();
        vm = new ProgressModalDialogVM() { Content = content };
        DataContext = vm;

    }
    public ProgressModalDialog() : this("Waaa") { }


    public void OnClosing(object?  sender, WindowClosingEventArgs e)
    {
        if (!shouldClose) e.Cancel = true;
    }


    public bool shouldClose = false;

    public void ForceClose()
    {
        shouldClose = true;
        Close();
    }



    public void OnOtherClosingPrevent(object? sender, WindowClosingEventArgs e)
    {
        e.Cancel = true;
    }

    public void ShowFromWindow(Window other)
    {
        other.IsEnabled = false;
        other.Closing += OnOtherClosingPrevent;
        Show();
    }

    public void CloseFromWindow(Window other)
    {
        other.IsEnabled = true;
        other.Closing -= OnOtherClosingPrevent;
        ForceClose();
    }
}
