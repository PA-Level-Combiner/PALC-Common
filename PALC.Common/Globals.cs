using System;
using System.IO;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace PALC;

public delegate Task AsyncEventHandler(object? sender, EventArgs e);
public delegate Task AsyncEventHandler<TEventArgs>(object? sender, TEventArgs e);



public static class GithubInfo
{
    public static readonly string owner = "PA-Level-Combiner";
    public static readonly string mainName = "PA-Level-Combiner-v3";
    public static readonly string mainUrl = @"https://github.com/PA-Level-Combiner/PA-Level-Combiner-v3";
    public static readonly string mainIssues = Path.Combine(mainUrl, "issues/");
    public static readonly string mainReleases = Path.Combine(mainUrl, "releases/");
}
