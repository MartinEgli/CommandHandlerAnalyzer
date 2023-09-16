using Microsoft.CodeAnalysis;
using static CommandHandlerAnalyzer.ResourcesExtensions;
using static CommandHandlerAnalyzer.Resources;
using static CommandHandlerAnalyzer.Base.RulesHelper;

namespace CommandHandlerAnalyzer;

public static class Rules
{
    public const string NameEndsWithCommandHandlerAnalyzerId = "NameEndsWithCommandHandlerAnalyzerId";
    public const string NameEndsNotWithCommandHandlerAnalyzerId = "NameEndsNotWithCommandHandlerAnalyzerId";
    private const string Category = "Naming";

    public static readonly DiagnosticDescriptor NameEndsWithCommandHandlerRule = CreateDescriptor(
        NameEndsWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor NameEndsNotWithCommandHandlerRule = CreateDescriptor(
        NameEndsNotWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));
}