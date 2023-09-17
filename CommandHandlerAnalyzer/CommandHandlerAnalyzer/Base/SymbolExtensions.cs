using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer.Base;

public static class SymbolExtensions
{
    public static bool Has<TAttribute>(this ITypeSymbol symbol) where TAttribute : Attribute
    {
        var result = symbol.HasType<TAttribute>() || symbol.HasBaseType<TAttribute>() || symbol.HasInterfaces<TAttribute>();
        return result;
    }


    public static bool Has<TAttribute>(this IPropertySymbol symbol) where TAttribute : Attribute
    {
        
        var type = symbol.Type;
        var result = type.HasType<TAttribute>() || type.HasBaseType<TAttribute>() || type.HasInterfaces<TAttribute>();
        return result;
    }

    public static bool Has<TAttribute>(this IFieldSymbol symbol) where TAttribute : Attribute
    {

        var type = symbol.Type;
        var result = type.HasType<TAttribute>() || type.HasBaseType<TAttribute>() || type.HasInterfaces<TAttribute>();
        return result;
    }

    public static bool Has<TAttribute>(this IParameterSymbol symbol) where TAttribute : Attribute
    {
        var type = symbol.Type;
        var result = type.HasType<TAttribute>() || type.HasBaseType<TAttribute>() || type.HasInterfaces<TAttribute>();
        return result;
    }


    private static bool HasInterfaces<TAttribute>(this ITypeSymbol type) where TAttribute : Attribute
    {
        var result = Enumerable.Any(type.Interfaces, @interface => @interface.Has<TAttribute>());
        return result;
    }

    private static bool HasBaseType<TAttribute>(this ITypeSymbol type) where TAttribute : Attribute
    {
        var result = type.BaseType != null && type.BaseType is not object && type.BaseType.Has<TAttribute>();
        return result;
    }

    private static bool HasType<TAttribute>(this ISymbol type) where TAttribute : Attribute
    {
        var result = type.GetAttributes().Any(it => it.AttributeClass!.Name.Equals(typeof(TAttribute).Name));
        return result;
    }

    public static Diagnostic Diagnostic(
        this ISymbol symbol,
        DiagnosticDescriptor descriptor,
        params object[] parameters)
    {
        return Microsoft.CodeAnalysis.Diagnostic.Create(descriptor, symbol.Locations[0], parameters);
    }
}