using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer.Base;

public static class SymbolExtensions
{
    public static bool Has<TAttribute>(this ITypeSymbol type) where TAttribute : Attribute
    {
        return type.HasType<TAttribute>() || type.HasBaseType<TAttribute>() || type.HasInterfaces<TAttribute>();
    }

    private static bool HasInterfaces<TAttribute>(this ITypeSymbol type) where TAttribute : Attribute
    {
        return Enumerable.Any(type.Interfaces, @interface => @interface.Has<TAttribute>());
    }

    private static bool HasBaseType<TAttribute>(this ITypeSymbol type) where TAttribute : Attribute
    {
        return type.BaseType != null && type.BaseType is not object && type.BaseType.Has<TAttribute>();
    }

    private static bool HasType<TAttribute>(this ISymbol type) where TAttribute : Attribute
    {
        return type.GetAttributes().Any(it => it.AttributeClass!.Name.Equals(typeof(TAttribute).Name));
    }

    public static Diagnostic Diagnostic(
        this ISymbol symbol,
        DiagnosticDescriptor descriptor,
        params object[] parameters)
    {
        return Microsoft.CodeAnalysis.Diagnostic.Create(descriptor, symbol.Locations[0], parameters);
    }
}