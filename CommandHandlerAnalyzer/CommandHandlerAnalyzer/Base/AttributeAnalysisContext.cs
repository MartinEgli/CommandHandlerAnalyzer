using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CommandHandlerAnalyzer.Base;

public class AttributeAnalysisContext<TAttribute> where TAttribute : Attribute
{
    private readonly AnalysisContext analysisContext;

    public AttributeAnalysisContext(AnalysisContext analysisContext)
    {
        this.analysisContext = analysisContext;
    }

    public void RegisterSymbolFieldTypeHasAttributeAction(Action<IFieldSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasFieldTypeAttribute(action), SymbolKind.Field);
    }

    public void RegisterSymbolFieldTypeHasNotAttributeAction(Action<IFieldSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasFieldTypeNotAttribute(action), SymbolKind.Field);
    }

    public void RegisterSymbolNamedTypeHasAttributeAction(Action<INamedTypeSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasTypeAttribute(action), SymbolKind.NamedType);
    }

    public void RegisterSymbolNamedTypeHasNotAttributeAction(Action<INamedTypeSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasTypeNotAttribute(action), SymbolKind.NamedType);
    }

    public void RegisterSymbolParameterTypeHasAttributeAction(Action<IParameterSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasParameterTypeAttribute(action), SymbolKind.Parameter);
    }

    public void RegisterSymbolParameterTypeHasNotAttributeAction(Action<IParameterSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasParameterTypeNotAttribute(action), SymbolKind.Parameter);
    }

    public void RegisterSymbolPropertyTypeHasAttributeAction(Action<IPropertySymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasPropertyTypeAttribute(action), SymbolKind.Property);
    }

    public void RegisterSymbolPropertyTypeHasNotAttributeAction(Action<IPropertySymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSymbolAction(HasPropertyTypeNotAttribute(action), SymbolKind.Property);
    }


    public void RegisterSyntaxNodePropertyTypeHasAttributeAction(Action<ILocalSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSyntaxNodeAction(HasLocalVariableTypeAttribute(action), SyntaxKind.LocalDeclarationStatement);
    }

    public void RegisterSyntaxNodePropertyTypeHasNotAttributeAction(Action<ILocalSymbol, Action<Diagnostic>> action)
    {
        analysisContext.RegisterSyntaxNodeAction(HasLocalVariableTypeNotAttribute(action), SyntaxKind.LocalDeclarationStatement);
    }



    private static Action<SyntaxNodeAnalysisContext> HasLocalVariableTypeAttribute(
        Action<ILocalSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            var localDeclaration = (LocalDeclarationStatementSyntax)it.Node;
            var variable = localDeclaration.Declaration.Variables.Single();
            var symbol = (ILocalSymbol)it.SemanticModel.GetDeclaredSymbol(variable)!;
            if (symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SyntaxNodeAnalysisContext> HasLocalVariableTypeNotAttribute(
        Action<ILocalSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            var localDeclaration = (LocalDeclarationStatementSyntax)it.Node;
            var variable = localDeclaration.Declaration.Variables.Single();
            var symbol = (ILocalSymbol)it.SemanticModel.GetDeclaredSymbol(variable)!;
            if (!symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }


    private static Action<SymbolAnalysisContext> HasTypeAttribute(
        Action<INamedTypeSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is INamedTypeSymbol symbol && symbol.Has<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SymbolAnalysisContext> HasFieldTypeAttribute(
        Action<IFieldSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is IFieldSymbol symbol && symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SymbolAnalysisContext> HasParameterTypeAttribute(
        Action<IParameterSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is IParameterSymbol symbol && symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SymbolAnalysisContext> HasPropertyTypeAttribute(
        Action<IPropertySymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is IPropertySymbol symbol && symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SymbolAnalysisContext> HasTypeNotAttribute(
        Action<INamedTypeSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is INamedTypeSymbol symbol && !symbol.Has<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SymbolAnalysisContext> HasFieldTypeNotAttribute(
        Action<IFieldSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is IFieldSymbol symbol && !symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SymbolAnalysisContext> HasParameterTypeNotAttribute(
        Action<IParameterSymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is IParameterSymbol symbol && !symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }

    private static Action<SymbolAnalysisContext> HasPropertyTypeNotAttribute(
        Action<IPropertySymbol, Action<Diagnostic>> analyze)
    {
        return it =>
        {
            if (it.Symbol is IPropertySymbol symbol && !symbol.HasType<TAttribute>())
                analyze(symbol, it.ReportDiagnostic);
        };
    }
}