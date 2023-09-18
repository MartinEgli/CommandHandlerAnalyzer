using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer.Base;

public static class NamedTypeSymbolExtensions
{
    private const string CommandHandler = "CommandHandler";
    private const string CommandHandler2 = "commandHandler";
    private const string CommandHandler3 = "_commandHandler";


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
        return symbol.Name.EndsWith(CommandHandler) || symbol.Name == CommandHandler2 || symbol.Name == CommandHandler3;
    }

    public static bool IsNameEndingWithCommandHandler(this IParameterSymbol symbol)
    {
        return symbol.Name.EndsWith(CommandHandler);
    }

    public static bool IsNameEndingWithCommandHandler(this ILocalSymbol symbol)
    {
        return symbol.Name.EndsWith(CommandHandler) || symbol.Name == CommandHandler2;
    }

}