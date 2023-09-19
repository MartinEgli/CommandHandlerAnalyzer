using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer.Base;

public static class NamedTypeSymbolExtensions
{

    public static bool IsNameEndingWith(this INamedTypeSymbol symbol, string name1)
    {
        return symbol.Name.EndsWith(name1);
    }

    public static bool IsNameEndingWith(this IPropertySymbol symbol, string name1)
    {
        return symbol.Name.EndsWith(name1);
    }

    public static bool IsNameEndingWith(this IFieldSymbol symbol, string name1, string name2,
        string name3)
    {
        return symbol.Name.EndsWith(name1) || symbol.Name == name2 || symbol.Name == name3;
    }

    public static bool IsNameEndingWith(this IParameterSymbol symbol, string name1, string name2)
    {
        return symbol.Name.EndsWith(name1) || symbol.Name == name2;
    }

    public static bool IsNameEndingWith(this ILocalSymbol symbol, string name1, string name2)
    {
        return symbol.Name.EndsWith(name1) || symbol.Name == name2;
    }
}