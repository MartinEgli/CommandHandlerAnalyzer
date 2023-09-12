using System;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer;

public static class SymbolExtensions
{
    public static bool Is<TAttribute>(this ITypeSymbol type) where TAttribute : Attribute
    {
        var attributes = type.GetAttributes();
        if(attributes.Any(it => it.AttributeClass!.Name.Equals(typeof(TAttribute).Name)))
        {
            return true;
        }

        if (type.BaseType != null && type.BaseType is not object && type.BaseType.Is<TAttribute>())
        {
            return true;
        }

        foreach (var @interface in type.Interfaces)
        {
            if (@interface.Is<TAttribute>())
            {
                return true;
            }
        }

        return false;
    }

    public static bool IsEnum(this ITypeSymbol symbol) => symbol.TypeKind == TypeKind.Enum;

    public static Diagnostic Diagnostic(
        this ISymbol symbol,
        DiagnosticDescriptor descriptor,
        params object[] parameters) =>
        Microsoft.CodeAnalysis.Diagnostic.Create(descriptor, symbol.Locations[0], parameters);
}