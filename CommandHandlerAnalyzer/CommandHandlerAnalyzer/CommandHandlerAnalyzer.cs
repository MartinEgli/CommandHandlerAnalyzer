using System.Collections.Immutable;
using CommandHandlerAnalyzer.Base;
using CommandHandlerAttributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CommandHandlerAnalyzer;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class CommandHandlerAnalyzer : AttributeDiagnosticAnalyzer<CommandHandlerAttribute>
{
    public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(
        Rules.NameEndsWithCommandHandlerRule,
        Rules.NameEndsNotWithCommandHandlerRule);

    protected override void Initialize(AttributeAnalysisContext<CommandHandlerAttribute> context)
    {
        void NameEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeNameEndsWithCommandHandler(typeSymbol =>
                typeSymbol.ViolatesNameEndsWithCommandHandler(typeSymbol.Name));
        }

        void NameNotEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeNameEndsNotWithCommandHandler(typeSymbol =>
                typeSymbol.ViolatesNameEndsNotWithCommandHandler(typeSymbol.Name));
        }

        context.RegisterSymbolHasAttributeAction(NameEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolHasNotAttributeAction(NameNotEndsWithCommandHandlerAnalyzer);
    }
}