using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandHandlerAnalyzer.Test;

public static class SampleDataLoader
{
    public static string LoadFromNamespaceOf<T>(string sampleName, string folder = "SampleData")
    {
        var stringBuilder = new StringBuilder();
        var type = typeof(T);
        var resourcePath = $"{type.Namespace!}.{folder}.{sampleName}";
        var assembly = type.Assembly;
        var sampleData = LoadResource(assembly!, resourcePath!);
        stringBuilder.AppendLine(sampleData);
        return stringBuilder.ToString();
    }

    private static string LoadResource(Assembly assembly, string resourcePath)
    {
        var manifestResourceStream = assembly.GetManifestResourceStream(resourcePath)! ??
                                     throw new InvalidOperationException($"Resource {resourcePath} not found in assembly {assembly.FullName}");
        using var reader = new StreamReader(manifestResourceStream);
        return reader.ReadToEnd();
    }

    public static async Task<string> LoadFromNamespaceOfAsync<T>(string sampleName, string folder = "SampleData")
    {
        var stringBuilder = new StringBuilder();
        var type = typeof(T);
        var resourcePath = $"{type.Namespace!}.{folder}.{sampleName}";
        var assembly = type.Assembly;
        var sampleData = await LoadResourceAsync(assembly!, resourcePath!);
        stringBuilder.AppendLine(sampleData);
        return stringBuilder.ToString();
    }

    private static async Task<string> LoadResourceAsync(Assembly assembly, string resourcePath)
    {
        var manifestResourceStream = assembly.GetManifestResourceStream(resourcePath)! ??
                                     throw new InvalidOperationException($"Resource {resourcePath} not found in assembly {assembly.FullName}");
        using var reader = new StreamReader(manifestResourceStream);
        return await reader.ReadToEndAsync();
    }
}