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
        var symbol = (INamedTypeSymbol)context.Symbol;
        if (!symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeNameEndsNotWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<INamedTypeSymbol, Diagnostic> onViolation)
    {
        var symbol = (INamedTypeSymbol)context.Symbol;
        if (symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzePropertyEndsWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<IPropertySymbol, Diagnostic> onViolation)
    {
        var symbol = (IPropertySymbol)context.Symbol;
        if (!symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
    }


    public static void AnalyzePropertyNotEndsWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<IPropertySymbol, Diagnostic> onViolation)
    {
        var symbol = (IPropertySymbol)context.Symbol;
        if (symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeFieldEndsWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<IFieldSymbol, Diagnostic> onViolation)
    {
        var symbol = (IFieldSymbol)context.Symbol;
        if (!symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
    }


    public static void AnalyzeFieldNotEndsWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<IFieldSymbol, Diagnostic> onViolation)
    {
        var symbol = (IFieldSymbol)context.Symbol;
        if (symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeParameterEndsWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<IParameterSymbol, Diagnostic> onViolation)
    {
        var symbol = (IParameterSymbol)context.Symbol;
        if (!symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
    }


    public static void AnalyzeParameterNotEndsWithCommandHandler(
        this SymbolAnalysisContext context,
        Func<IParameterSymbol, Diagnostic> onViolation)
    {
        var symbol = (IParameterSymbol)context.Symbol;
        if (symbol.IsNameEndingWithCommandHandler()) context.ReportDiagnostic(onViolation(symbol));
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

    public static Diagnostic ViolatesPropertyEndsWithCommandHandler(
        this IPropertySymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.PropertyEndsWithCommandHandlerRule, parameters);
    }
    
    public static Diagnostic ViolatesPropertyNotEndsWithCommandHandler(
        this IPropertySymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.PropertyEndsNotWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesFieldEndsWithCommandHandler(
        this IFieldSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.FieldEndsWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesFieldNotEndsWithCommandHandler(
        this IFieldSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.FieldEndsNotWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesParameterEndsWithCommandHandler(
        this IParameterSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.ParameterEndsWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesParameterNotEndsWithCommandHandler(
        this IParameterSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.ParameterEndsNotWithCommandHandlerRule, parameters);
    }
}