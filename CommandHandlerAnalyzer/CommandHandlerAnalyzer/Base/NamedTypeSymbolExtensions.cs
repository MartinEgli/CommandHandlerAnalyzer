using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer.Base;

public static class NamedTypeSymbolExtensions
{
    private const string CommandHandler = "CommandHandler";

    public static bool IsNameEndingWithCommandHandler(this INamedTypeSymbol symbol)
    {
        return symbol.Name.EndsWith(CommandHandler);
    }

    public static bool IsNameEndingWithCommandHandler(this IPropertySymbol symbol)
    {
        return symbol.Name.EndsWith(CommandHandler);
    }

    public static bool IsNameEndingWithCommandHandler(this IFieldSymbol symbol)
    {
        return symbol.Name.EndsWith(CommandHandler);
    }

    public static bool IsNameEndingWithCommandHandler(this IParameterSymbol symbol)
    {
        return symbol.Name.EndsWith(CommandHandler);
    }

}