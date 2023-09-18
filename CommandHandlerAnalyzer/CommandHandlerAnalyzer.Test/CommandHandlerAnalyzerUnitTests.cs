using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using static CommandHandlerAnalyzer.Test.ExpectedResults;
using VerifyCS = CommandHandlerAnalyzer.Test.CSharpCodeFixVerifier<
    CommandHandlerAnalyzer.CommandHandlerAnalyzer,
    CommandHandlerAnalyzer.CommandHandlerAnalyzerCodeFixProvider>;

namespace CommandHandlerAnalyzer.Test;

[TestClass]
public class CommandHandlerAnalyzerUnitTest
{
    [TestMethod]
    public async Task CommandHandlerAnalyzer_ClassEndWithCommandHandler_DoesNotEmitAnyViolations()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>("ClassEndWithCommandHandler.cs");
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
    }


    [TestMethod]
    public async Task CommandHandlerAnalyzer_ClassNotEndWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>("ClassNotEndWithCommandHandler.cs");
        var compileError = CompilerError(Rules.NameEndsWithCommandHandlerAnalyzerId).WithSpan(5, 16, 5, 24);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_ClassEndWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>("Class3CommandHandler.cs");
        var compileError = CompilerError(Rules.NameEndsNotWithCommandHandlerAnalyzerId).WithSpan(3, 14, 3, 34);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_PropertyEndsWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>("PropertyEndsWithCommandHandler.cs");
        var compileError = CompilerError(Rules.PropertyEndsWithCommandHandlerAnalyzerId).WithSpan(7, 28, 7, 37);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }


    [TestMethod]
    public async Task CommandHandlerAnalyzer_PropertyEndsNotWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>(
                "PropertyEndsNotWithCommandHandler.cs");
        var compileError = CompilerError(Rules.PropertyEndsNotWithCommandHandlerAnalyzerId).WithSpan(7, 17, 7, 40);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_ParameterEndsWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>("ParameterEndsWithCommandHandler.cs");
        var compileError = CompilerError(Rules.ParameterEndsWithCommandHandlerAnalyzerId).WithSpan(7, 41, 7, 51);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }


    [TestMethod]
    public async Task CommandHandlerAnalyzer_ParameterEndsNotWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>(
                "ParameterEndsNotWithCommandHandler.cs");
        var compileError = CompilerError(Rules.ParameterEndsNotWithCommandHandlerAnalyzerId).WithSpan(7, 30, 7, 54);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_LocalEndsWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>(
                "LocalEndsWithCommandHandler.cs");
        var compileError = CompilerError(Rules.LocalEndsWithCommandHandlerAnalyzerId).WithSpan(9, 13, 9, 17);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }


    [TestMethod]
    public async Task CommandHandlerAnalyzer_LocalEndsNouWithCommandHandler_EmitsError()
    {
        var validEntity =
            SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>(
                "LocalEndsNotWithCommandHandler.cs");
        var compileError = CompilerError(Rules.LocalEndsNotWithCommandHandlerAnalyzerId).WithSpan(9, 13, 9, 31);
        await VerifyCS.VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }
}


