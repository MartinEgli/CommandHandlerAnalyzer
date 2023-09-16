using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer;

internal static class ResourcesExtensions
{
    internal static LocalizableResourceString Resource(string name)
    {
        return new LocalizableResourceString(name,
            Resources.ResourceManager,
            typeof(Resources));
    }
}