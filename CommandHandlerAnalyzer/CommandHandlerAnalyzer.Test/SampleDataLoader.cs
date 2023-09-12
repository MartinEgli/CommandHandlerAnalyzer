using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace CommandHandlerAnalyzer.Test;

public static class SampleDataLoader
{
    public static string LoadFromNamespaceOf<T>(string sampleName)
    {
        var stringBuilder = new StringBuilder();
        var type = typeof(T);
        var resourcePath = $"{type.Namespace!}.SampleData.{sampleName}";
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
}