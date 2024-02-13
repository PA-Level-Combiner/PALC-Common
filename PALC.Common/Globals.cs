using System;
using System.IO;
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



public static class AdditionalErrors
{
    public static readonly string noAccessHelp = $"Try running the program as admin or change your folder / file permissions.";
}


public static class GithubInfo
{
    public static readonly string owner = "PA-Level-Combiner";
    public static readonly string mainName = "PA-Level-Combiner-v3";
    public static readonly string mainUrl = @"https://github.com/PA-Level-Combiner/PA-Level-Combiner-v3";
    public static readonly string mainIssues = Path.Combine(mainUrl, "issues/");
    public static readonly string mainReleases = Path.Combine(mainUrl, "releases/");
}
