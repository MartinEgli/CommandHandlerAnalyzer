using System;
using CommandHandlerAnalyzer.Base;
using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer;

public static class Diagnostics
{
    private const string CommandHandler1 = "CommandHandler";
    private const string CommandHandler2 = "commandHandler";
    private const string CommandHandler3 = "_commandHandler";

    public static bool IsNameEndingWithCommandHandler(this INamedTypeSymbol symbol)
    {
        return symbol.IsNameEndingWith(CommandHandler1);
    }

    public static bool IsNameEndingWithCommandHandler(this IPropertySymbol symbol)
    {
        return symbol.IsNameEndingWith(CommandHandler1);
    }

    public static bool IsNameEndingWithCommandHandler(this IFieldSymbol symbol)
    {
        return symbol.IsNameEndingWith(CommandHandler1, CommandHandler2, CommandHandler3);
    }

    public static bool IsNameEndingWithCommandHandler(this IParameterSymbol symbol)
    {
        return symbol.IsNameEndingWith(CommandHandler1, CommandHandler2);
    }

    public static bool IsNameEndingWithCommandHandler(this ILocalSymbol symbol)
    {
        return symbol.IsNameEndingWith(CommandHandler1, CommandHandler2);
    }

    public static void AnalyzeFieldEndsWithCommandHandler(
        this IFieldSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<IFieldSymbol, Diagnostic> onViolation)
    {
        if (!symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeFieldNotEndsWithCommandHandler(
        this IFieldSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<IFieldSymbol, Diagnostic> onViolation)
    {
        if (symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeLocalEndsWithCommandHandler(
        this ILocalSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<ILocalSymbol, Diagnostic> onViolation)
    {
        if (!symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeLocalNotEndsWithCommandHandler(
        this ILocalSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<ILocalSymbol, Diagnostic> onViolation)
    {
        if (symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeNameEndsNotWithCommandHandler(
        this INamedTypeSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<INamedTypeSymbol, Diagnostic> onViolation)
    {
        if (symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeNameEndsWithCommandHandler(
        this INamedTypeSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<INamedTypeSymbol, Diagnostic> onViolation)
    {
        if (!symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeParameterEndsWithCommandHandler(
        this IParameterSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<IParameterSymbol, Diagnostic> onViolation)
    {
        if (!symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzeParameterNotEndsWithCommandHandler(
        this IParameterSymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<IParameterSymbol, Diagnostic> onViolation)
    {
        if (symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzePropertyEndsWithCommandHandler(
        this IPropertySymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<IPropertySymbol, Diagnostic> onViolation)
    {
        if (!symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
    }

    public static void AnalyzePropertyNotEndsWithCommandHandler(
        this IPropertySymbol symbol,
        Action<Diagnostic> reportDiagnostic,
        Func<IPropertySymbol, Diagnostic> onViolation)
    {
        if (symbol.IsNameEndingWithCommandHandler()) reportDiagnostic(onViolation(symbol));
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

    public static Diagnostic ViolatesLocalEndsWithCommandHandler(
        this ILocalSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.LocalEndsWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesLocalNotEndsWithCommandHandler(
        this ILocalSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.LocalEndsNotWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesNameEndsNotWithCommandHandler(
        this INamedTypeSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.NameEndsNotWithCommandHandlerRule, parameters);
    }

    public static Diagnostic ViolatesNameEndsWithCommandHandler(
        this INamedTypeSymbol symbol,
        params object[] parameters)
    {
        return symbol.Diagnostic(Rules.NameEndsWithCommandHandlerRule, parameters);
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
}