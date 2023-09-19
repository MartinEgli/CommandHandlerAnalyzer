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
        void TypeNameEndsWithCommandHandlerAnalyzer(INamedTypeSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeNameEndsWithCommandHandler(
                reporter,
                s => s.ViolatesNameEndsWithCommandHandler(s.Name));
        }

        void TypeNameNotEndsWithCommandHandlerAnalyzer(INamedTypeSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeNameEndsNotWithCommandHandler(
                reporter,
                s => s.ViolatesNameEndsNotWithCommandHandler(s.Name));
        }

        void PropertyNameEndsWithCommandHandlerAnalyzer(IPropertySymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzePropertyEndsWithCommandHandler(
                reporter,
                s => s.ViolatesPropertyEndsWithCommandHandler(s.Name));
        }

        void PropertyNameNotEndsWithCommandHandlerAnalyzer(IPropertySymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzePropertyNotEndsWithCommandHandler(
                reporter,
                s => s.ViolatesPropertyNotEndsWithCommandHandler(s.Name));
        }

        void FieldNameEndsWithCommandHandlerAnalyzer(IFieldSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeFieldEndsWithCommandHandler(
                reporter,
                s => s.ViolatesFieldEndsWithCommandHandler(s.Name));
        }

        void FieldNameNotEndsWithCommandHandlerAnalyzer(IFieldSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeFieldNotEndsWithCommandHandler(
                reporter,
                s => s.ViolatesFieldNotEndsWithCommandHandler(s.Name));
        }

        void ParameterNameEndsWithCommandHandlerAnalyzer(IParameterSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeParameterEndsWithCommandHandler(
                reporter,
                s => s.ViolatesParameterEndsWithCommandHandler(s.Name));
        }

        void ParameterNameNotEndsWithCommandHandlerAnalyzer(IParameterSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeParameterNotEndsWithCommandHandler(
                reporter,
                s => s.ViolatesParameterNotEndsWithCommandHandler(s.Name));
        }

        void LocalNameEndsWithCommandHandlerAnalyzer(ILocalSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeLocalEndsWithCommandHandler(
                reporter,
                s => s.ViolatesLocalEndsWithCommandHandler(s.Name));
        }

        void LocalNameNotEndsWithCommandHandlerAnalyzer(ILocalSymbol symbol, Action<Diagnostic> reporter)
        {
            symbol.AnalyzeLocalNotEndsWithCommandHandler(
                reporter,
                s => s.ViolatesLocalNotEndsWithCommandHandler(s.Name));
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