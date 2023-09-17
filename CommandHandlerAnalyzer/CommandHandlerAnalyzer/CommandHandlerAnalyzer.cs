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
        Rules.NameEndsNotWithCommandHandlerRule,
        Rules.PropertyEndsWithCommandHandlerRule,
        Rules.PropertyEndsNotWithCommandHandlerRule,
        Rules.FieldEndsWithCommandHandlerRule,
        Rules.FieldEndsNotWithCommandHandlerRule,
        Rules.ParameterEndsWithCommandHandlerRule,
        Rules.ParameterEndsNotWithCommandHandlerRule);


    protected override void Initialize(AttributeAnalysisContext<CommandHandlerAttribute> context)
    {
        void NameEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeNameEndsWithCommandHandler(symbol =>
                symbol.ViolatesNameEndsWithCommandHandler(symbol.Name));
        }

        void NameNotEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeNameEndsNotWithCommandHandler(symbol =>
                symbol.ViolatesNameEndsNotWithCommandHandler(symbol.Name));
        }

        void PropertyEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzePropertyEndsWithCommandHandler(symbol =>
                symbol.ViolatesPropertyEndsWithCommandHandler(symbol.Name));
        }

        void PropertyNotEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzePropertyNotEndsWithCommandHandler(symbol =>
                symbol.ViolatesPropertyNotEndsWithCommandHandler(symbol.Name));
        }

        void FieldEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeFieldEndsWithCommandHandler(symbol =>
                symbol.ViolatesFieldEndsWithCommandHandler(symbol.Name));
        }

        void FieldNotEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeFieldNotEndsWithCommandHandler(symbol =>
                symbol.ViolatesFieldNotEndsWithCommandHandler(symbol.Name));
        }


        void MethodParameterEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeParameterEndsWithCommandHandler(symbol =>
                symbol.ViolatesParameterEndsWithCommandHandler(symbol.Name));
        }

        void MethodParameterNotEndsWithCommandHandlerAnalyzer(SymbolAnalysisContext it)
        {
            it.AnalyzeParameterNotEndsWithCommandHandler(symbol =>
                symbol.ViolatesParameterNotEndsWithCommandHandler(symbol.Name));
        }


        context.RegisterSymbolNamedTypeHasAttributeAction(NameEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolNamedTypeHasNotAttributeAction(NameNotEndsWithCommandHandlerAnalyzer);

        context.RegisterSymbolPropertyHasAttributeAction(PropertyEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolPropertyHasNotAttributeAction(PropertyNotEndsWithCommandHandlerAnalyzer);

        context.RegisterSymbolFieldHasAttributeAction(FieldEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolFieldHasNotAttributeAction(FieldNotEndsWithCommandHandlerAnalyzer);

        context.RegisterSymbolParameterHasAttributeAction(MethodParameterEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolParameterHasNotAttributeAction(MethodParameterNotEndsWithCommandHandlerAnalyzer);


    }
}