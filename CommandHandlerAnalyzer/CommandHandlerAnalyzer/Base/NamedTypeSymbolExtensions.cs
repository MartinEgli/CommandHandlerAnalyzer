using Microsoft.CodeAnalysis;

namespace CommandHandlerAnalyzer.Base;

public static class NamedTypeSymbolExtensions
{
    private const string CommandHandler = "CommandHandler";

    public static bool IsNameEndingWithCommandHandler(this INamedTypeSymbol namedTypeSymbol)
    {
        return namedTypeSymbol.Name.EndsWith(CommandHandler);
    }
}