using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static CommandHandlerAnalyzer.Test.CSharpCodeFixVerifier<CommandHandlerAnalyzer.CommandHandlerAnalyzer,
    CommandHandlerAnalyzer.CommandHandlerAnalyzerCodeFixProvider>;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using static CommandHandlerAnalyzer.Test.ExpectedResults;
using static CommandHandlerAnalyzer.Test.SampleDataLoader;

namespace CommandHandlerAnalyzer.Test;

[TestClass]
public class CommandHandlerAnalyzerUnitTest
{
    [TestMethod]
    public async Task CommandHandlerAnalyzer_ClassEndWithCommandHandler_DoesNotEmitAnyViolations()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>("ClassEndWithCommandHandler.cs");
        await VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
    }


    [TestMethod]
    public async Task CommandHandlerAnalyzer_ClassEndWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "ClassEndWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.NameEndsNotWithCommandHandlerAnalyzerId).WithSpan(3, 14, 3, 33);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_ClassNotEndWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "ClassNotEndWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.NameEndsWithCommandHandlerAnalyzerId).WithSpan(5, 16, 5, 24);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_LocalEndsNouWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "LocalEndsNotWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.LocalEndsNotWithCommandHandlerAnalyzerId).WithSpan(9, 13, 9, 31);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_LocalEndsWithCommandHandler_DoesNotEmitAnyViolations()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "LocalEndsWithCommandHandler.cs");
        await VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_LocalEndsWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "LocalEndsWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.LocalEndsWithCommandHandlerAnalyzerId).WithSpan(9, 13, 9, 17);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_ParameterEndsNotWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "ParameterEndsNotWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.ParameterEndsNotWithCommandHandlerAnalyzerId).WithSpan(7, 30, 7, 54);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_ParameterEndsWithCommandHandler_DoesNotEmitAnyViolations()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>("ParameterEndsWithCommandHandler.cs");
        await VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_ParameterEndsWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "ParameterEndsWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.ParameterEndsWithCommandHandlerAnalyzerId).WithSpan(7, 41, 7, 51);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_PropertyEndsNotWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "PropertyEndsNotWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.PropertyEndsNotWithCommandHandlerAnalyzerId).WithSpan(7, 17, 7, 40);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_PropertyEndsWithCommandHandler_DoesNotEmitAnyViolations()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>("PropertyEndsWithCommandHandler.cs");
        await VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_PropertyEndsWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "PropertyEndsWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.PropertyEndsWithCommandHandlerAnalyzerId).WithSpan(7, 28, 7, 37);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_FieldEndsNotWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "FieldEndsNotWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.FieldEndsNotWithCommandHandlerAnalyzerId).WithSpan(7, 18, 7, 41);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_FieldEndsWithCommandHandler_DoesNotEmitAnyViolations()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>("FieldEndsWithCommandHandler.cs");
        await VerifyAnalyzerAsync(validEntity, ShouldNotEmitAnyIssues());
    }

    [TestMethod]
    public async Task CommandHandlerAnalyzer_FieldEndsWithCommandHandler_EmitsError()
    {
        var validEntity =
            await LoadFromNamespaceOfAsync<CommandHandlerAnalyzerUnitTest>(
                "FieldEndsWithCommandHandlerViolation.cs");
        var compileError = CompilerError(Rules.FieldEndsWithCommandHandlerAnalyzerId).WithSpan(7, 29, 7, 38);
        await VerifyAnalyzerAsync(validEntity, ShouldEmitIssues(compileError));
    }
}