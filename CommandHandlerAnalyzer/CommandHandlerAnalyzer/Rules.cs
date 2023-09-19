using Microsoft.CodeAnalysis;
using static CommandHandlerAnalyzer.ResourcesExtensions;
using static CommandHandlerAnalyzer.Resources;
using static CommandHandlerAnalyzer.Base.RulesHelper;

namespace CommandHandlerAnalyzer;

public static class Rules
{
    public const string NameEndsWithCommandHandlerAnalyzerId = "NameEndsWithCommandHandlerAnalyzerId";
    public const string NameEndsNotWithCommandHandlerAnalyzerId = "NameEndsNotWithCommandHandlerAnalyzerId";
    public const string PropertyEndsWithCommandHandlerAnalyzerId = "PropertyEndsWithCommandHandlerAnalyzerId";
    public const string PropertyEndsNotWithCommandHandlerAnalyzerId = "PropertyEndsNotWithCommandHandlerAnalyzerId";
    public const string FieldEndsWithCommandHandlerAnalyzerId = "FieldEndsWithCommandHandlerAnalyzerId";
    public const string FieldEndsNotWithCommandHandlerAnalyzerId = "FieldEndsNotWithCommandHandlerAnalyzerId";
    public const string ParameterEndsWithCommandHandlerAnalyzerId = "ParameterEndsWithCommandHandlerAnalyzerId";
    public const string ParameterEndsNotWithCommandHandlerAnalyzerId = "ParameterFieldEndsNotWithCommandHandlerAnalyzerId";
    public const string LocalEndsWithCommandHandlerAnalyzerId = "LocalEndsWithCommandHandlerAnalyzerId";
    public const string LocalEndsNotWithCommandHandlerAnalyzerId = "LocalFieldEndsNotWithCommandHandlerAnalyzerId";
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

    public static readonly DiagnosticDescriptor PropertyEndsWithCommandHandlerRule = CreateDescriptor(
        PropertyEndsWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor PropertyEndsNotWithCommandHandlerRule = CreateDescriptor(
        PropertyEndsNotWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor FieldEndsWithCommandHandlerRule = CreateDescriptor(
        FieldEndsWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor FieldEndsNotWithCommandHandlerRule = CreateDescriptor(
        FieldEndsNotWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor ParameterEndsWithCommandHandlerRule = CreateDescriptor(
        ParameterEndsWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor ParameterEndsNotWithCommandHandlerRule = CreateDescriptor(
        ParameterEndsNotWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor LocalEndsWithCommandHandlerRule = CreateDescriptor(
        LocalEndsWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

    public static readonly DiagnosticDescriptor LocalEndsNotWithCommandHandlerRule = CreateDescriptor(
        LocalEndsNotWithCommandHandlerAnalyzerId,
        Resource(nameof(AnalyzerTitle)),
        Resource(nameof(AnalyzerMessageFormat)),
        Resource(nameof(AnalyzerDescription)));

}