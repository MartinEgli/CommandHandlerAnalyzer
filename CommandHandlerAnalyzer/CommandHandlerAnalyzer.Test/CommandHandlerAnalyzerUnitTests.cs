﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using static Microsoft.CodeAnalysis.Testing.DiagnosticResult;
using static CommandHandlerAnalyzer.Test.ExpectedResults;

using VerifyCS = CommandHandlerAnalyzer.Test.CSharpCodeFixVerifier<
    CommandHandlerAnalyzer.CommandHandlerAnalyzer,
    CommandHandlerAnalyzer.CommandHandlerAnalyzerCodeFixProvider>;

namespace CommandHandlerAnalyzer.Test
{
    [TestClass]
    public class CommandHandlerAnalyzerUnitTest
    {

        [TestMethod]
        public async Task CommandHandlerAnalyzer_ClassEndWithCommandHandler_DoesNotEmitAnyViolations()
        {
            var validEntity = SampleDataLoader.LoadFromNamespaceOf<CommandHandlerAnalyzerUnitTest>("ClassEndWithCommandHandler.cs");
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

    }
}
