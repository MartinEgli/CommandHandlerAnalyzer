using System;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CommandHandlerAnalyzer.Base;

public abstract class AttributeDiagnosticAnalyzer<TAttribute> : DiagnosticAnalyzer where TAttribute : Attribute
{
    public sealed override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                               GeneratedCodeAnalysisFlags.ReportDiagnostics);
        Initialize(new AttributeAnalysisContext<TAttribute>(context));
        context.EnableConcurrentExecution();
    }

    protected abstract void Initialize(AttributeAnalysisContext<TAttribute> context);
}