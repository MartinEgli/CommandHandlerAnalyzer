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

    public void RegisterSymbolHasAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasAttribute(action), SymbolKind.NamedType);
    }

    public void RegisterSymbolHasNotAttributeAction(Action<SymbolAnalysisContext> action)
    {
        analysisContext.RegisterSymbolAction(HasNotAttribute(action), SymbolKind.NamedType);
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

    private static Action<SymbolAnalysisContext> HasNotAttribute(
        Action<SymbolAnalysisContext> analyze)
    {
        return it =>
        {
            if (it.Symbol is ITypeSymbol classSymbol && !classSymbol.Has<TAttribute>())
                analyze(it);
        };
    }
}