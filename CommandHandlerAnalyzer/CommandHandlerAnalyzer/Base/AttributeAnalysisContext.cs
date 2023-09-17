using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CommandHandlerAnalyzer.Base;

public class AttributeAnalysisContext<TAttribute> where TAttribute : Attribute
{
    private readonly AnalysisContext analysisContext;

    public AttributeAnalysisContext(AnalysisContext analysisContext)
    {
        this.analysisContext = analysisContext;
    }

    public void RegisterSymbolFieldHasAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasAttributeField(action), SymbolKind.Field);
    }

    public void RegisterSymbolFieldHasNotAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasNotAttributeField(action), SymbolKind.Field);
    }

    public void RegisterSymbolMethodHasAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasAttribute(action), SymbolKind.Method);
    }

    public void RegisterSymbolMethodHasNotAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasNotAttribute(action), SymbolKind.Method);
    }

    public void RegisterSymbolNamedTypeHasAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasAttribute(action), SymbolKind.NamedType);
    }

    public void RegisterSymbolNamedTypeHasNotAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasNotAttribute(action), SymbolKind.NamedType);
    }

    public void RegisterSymbolParameterHasAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasAttributeParameter(action), SymbolKind.Parameter);
    }

    public void RegisterSymbolParameterHasNotAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasNotAttributeParameter(action), SymbolKind.Parameter);
    }

    public void RegisterSymbolPropertyHasAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasAttributeProperty(action), SymbolKind.Property);
    }

    public void RegisterSymbolPropertyHasNotAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasNotAttributeProperty(action), SymbolKind.Property);
    }

    private static Action<SymbolAnalysisContext> HasAttribute(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is ITypeSymbol classSymbol && classSymbol.Has<TAttribute>())
                analyze(it);
        };
    }

    private static Action<SymbolAnalysisContext> HasAttributeField(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is IFieldSymbol fieldSymbol && fieldSymbol.Has<TAttribute>())
                analyze(it);
        };
    }

    private static Action<SymbolAnalysisContext> HasAttributeParameter(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is IParameterSymbol symbol && symbol.Has<TAttribute>())
                analyze(it);
        };
    }

    private static Action<SymbolAnalysisContext> HasAttributeProperty(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is IPropertySymbol propertySymbol && propertySymbol.Has<TAttribute>())
                analyze(it);
        };
    }

    private static Action<SymbolAnalysisContext> HasNotAttribute(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is ITypeSymbol classSymbol && !classSymbol.Has<TAttribute>())
                analyze(it);
        };
    }

    private static Action<SymbolAnalysisContext> HasNotAttributeField(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is IFieldSymbol fieldSymbol && !fieldSymbol.Has<TAttribute>())
                analyze(it);
        };
    }

    private static Action<SymbolAnalysisContext> HasNotAttributeParameter(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is IParameterSymbol symbol && !symbol.Has<TAttribute>())
                analyze(it);
        };
    }

    private static Action<SymbolAnalysisContext> HasNotAttributeProperty(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is IPropertySymbol propertySymbol && !propertySymbol.Has<TAttribute>())
                analyze(it);
        };
    }
}