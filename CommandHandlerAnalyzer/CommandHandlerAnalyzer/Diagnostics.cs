using System;
using CommandHandlerAnalyzer.Base;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CommandHandlerAnalyzer;

public static class Diagnostics
{
    public static void AnalyzeNameEndsWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<INamedTypeSymbol, Diagnostic> onViolation)
    {
        var classSymbol = (INamedTypeSymbol)context.Symbol;
        if (!classSymbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(classSymbol));
    }

    public static void AnalyzeNameEndsNotWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<INamedTypeSymbol, Diagnostic> onViolation)
    {
        var classSymbol = (INamedTypeSymbol)context.Symbol;
        if (classSymbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(classSymbol));
    }

    public static Diagnostic ViolatesNameEndsWithCommandHandler(
        this INamedTypeSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.NameEndsWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesNameEndsNotWithCommandHandler(
        this INamedTypeSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.NameEndsNotWithCommandHandlerRule, parameters);
    }
}