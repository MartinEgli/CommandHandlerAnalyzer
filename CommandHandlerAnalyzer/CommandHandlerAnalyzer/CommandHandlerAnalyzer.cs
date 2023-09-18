using System;
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
        Rules.ParameterEndsNotWithCommandHandlerRule,
        Rules.LocalEndsWithCommandHandlerRule,
        Rules.LocalEndsNotWithCommandHandlerRule);

    protected override void Initialize(AttributeAnalysisContext<CommandHandlerAttribute> context)
    {
        void TypeNameEndsWithCommandHandlerAnalyzer(INamedTypeSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeNameEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesNameEndsWithCommandHandler(symbol.Name));
        }

        void TypeNameNotEndsWithCommandHandlerAnalyzer(INamedTypeSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeNameEndsNotWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesNameEndsNotWithCommandHandler(symbol.Name));
        }

        void PropertyNameEndsWithCommandHandlerAnalyzer(IPropertySymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzePropertyEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesPropertyEndsWithCommandHandler(symbol.Name));
        }

        void PropertyNameNotEndsWithCommandHandlerAnalyzer(IPropertySymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzePropertyNotEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesPropertyNotEndsWithCommandHandler(symbol.Name));
        }

        void FieldNameEndsWithCommandHandlerAnalyzer(IFieldSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeFieldEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesFieldEndsWithCommandHandler(symbol.Name));
        }

        void FieldNameNotEndsWithCommandHandlerAnalyzer(IFieldSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeFieldNotEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesFieldNotEndsWithCommandHandler(symbol.Name));
        }

        void ParameterNameEndsWithCommandHandlerAnalyzer(IParameterSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeParameterEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesParameterEndsWithCommandHandler(symbol.Name));
        }

        void ParameterNameNotEndsWithCommandHandlerAnalyzer(IParameterSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeParameterNotEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesParameterNotEndsWithCommandHandler(symbol.Name));
        }

        void LocalNameEndsWithCommandHandlerAnalyzer(ILocalSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeLocalEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesLocalEndsWithCommandHandler(symbol.Name));
        }

        void LocalNameNotEndsWithCommandHandlerAnalyzer(ILocalSymbol it, Action<Diagnostic> reporter)
        {
            it.AnalyzeLocalNotEndsWithCommandHandler(
                reporter,
                symbol => symbol.ViolatesLocalNotEndsWithCommandHandler(symbol.Name));
        }

        context.RegisterSymbolNamedTypeHasAttributeAction(TypeNameEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolNamedTypeHasNotAttributeAction(TypeNameNotEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolPropertyTypeHasAttributeAction(PropertyNameEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolPropertyTypeHasNotAttributeAction(PropertyNameNotEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolFieldTypeHasAttributeAction(FieldNameEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolFieldTypeHasNotAttributeAction(FieldNameNotEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolParameterTypeHasAttributeAction(ParameterNameEndsWithCommandHandlerAnalyzer);
        context.RegisterSymbolParameterTypeHasNotAttributeAction(ParameterNameNotEndsWithCommandHandlerAnalyzer);
        context.RegisterSyntaxNodePropertyTypeHasAttributeAction(LocalNameEndsWithCommandHandlerAnalyzer);
        context.RegisterSyntaxNodePropertyTypeHasNotAttributeAction(LocalNameNotEndsWithCommandHandlerAnalyzer);
    }
}