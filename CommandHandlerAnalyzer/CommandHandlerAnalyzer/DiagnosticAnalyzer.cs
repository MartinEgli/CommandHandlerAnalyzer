using System;
using Microsoft.CodeAnalysis.Diagnostics;

namespace CommandHandlerAnalyzer;

public abstract class DiagnosticAnalyzer<TAttribute> : DiagnosticAnalyzer where TAttribute : Attribute
{
    public sealed override void Initialize(AnalysisContext context)
    {
        context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze |
                                               GeneratedCodeAnalysisFlags.ReportDiagnostics);
        Initialize(new AnalysisContext<TAttribute>(context));
        context.EnableConcurrentExecution();
    }

    protected abstract void Initialize(AnalysisContext<TAttribute> context);
}