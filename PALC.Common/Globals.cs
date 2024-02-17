using CommunityToolkit.Mvvm.ComponentModel;
using Semver;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PALC;

public delegate Task AsyncEventHandler(object? sender, EventArgs e);
public delegate Task AsyncEventHandler<TEventArgs>(object? sender, TEventArgs e);

public static class AEHHelper
{
    public static async Task RunAEH<TEventArgs>(AsyncEventHandler<TEventArgs>? aeh, object? sender, TEventArgs args)
    {
        if (aeh != null) await aeh(sender, args);
    }
    public static async Task RunAEH(AsyncEventHandler? aeh, object? sender)
    {
        if (aeh != null) await aeh(sender, EventArgs.Empty);
    }
}

public class DisplayErrorArgs<TException>(string message, TException ex) where TException : Exception?
{
    public string message = message;
    public TException ex = ex;
}
public class DisplayGeneralErrorArgs(string message, Exception? ex) : DisplayErrorArgs<Exception?>(message, ex) { }



public static class ErrorHelper
{
    public static bool IsFileException(Exception ex)
        => ex is UnauthorizedAccessException ||
        ex is PathTooLongException ||
        ex is DirectoryNotFoundException ||
        ex is FileNotFoundException;
        
}


public class GithubInfo(string name)
{
    public readonly string name = name;
    public readonly string url = $"https://github.com/{owner}/{name}";
    public string Issues => Path.Combine(url, "issues/");
    public string Releases => Path.Combine(url, "releases/");


    public static readonly string owner = "PA-Level-Combiner";

    public static readonly GithubInfo main = new("PA-Level-Combiner-v3");
    public static readonly GithubInfo updater = new("PALC.Updater");
}

public partial class ProgramInfo : ObservableObject
{
    public static SemVersion GetProgramVersion()
    {
        var ass = Assembly.GetEntryAssembly() ?? throw new NullReferenceException("No entry assembly found.");
        string version = (FileVersionInfo.GetVersionInfo(ass.Location).ProductVersion?.Split("+")[0])
            ?? throw new NullReferenceException("Product version is missing.");

        return SemVersion.Parse(version, SemVersionStyles.Any);
    }

    public ProgramInfo() { }

    [ObservableProperty]
    public SemVersion programVersion = GetProgramVersion();
}
