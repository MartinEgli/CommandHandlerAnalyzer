using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer.Base;

internal static class RulesHelper
{
    private const string DefaultCategory = "Naming";

    internal static DiagnosticDescriptor CreateDescriptor(
        string id,
        LocalizableResourceString title,
        LocalizableResourceString messageFormat,
        LocalizableResourceString description,
        string category = DefaultCategory,
        DiagnosticSeverity severity = DiagnosticSeverity.Error,
        bool isEnabledByDefault = true) =>
        new(
            id,
            title,
            messageFormat,
            category,
            severity,
            isEnabledByDefault,
            description);
}