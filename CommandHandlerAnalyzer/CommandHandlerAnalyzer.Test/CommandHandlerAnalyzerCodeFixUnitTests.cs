using System.Threading.Tasks;
using ConsoleApplication2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VerifyCS = CommandHandlerAnalyzer.Test.CSharpCodeFixVerifier<
    CommandHandlerAnalyzer.CommandHandlerAnalyzer,
    CommandHandlerAnalyzer.CommandHandlerAnalyzerCodeFixProvider>;

namespace CommandHandlerAnalyzer.Test;

[TestClass]
public class CommandHandlerAnalyzerCodeFixUnitTest
{
    [TestMethod]
    public async Task CommandHandlerAnalyzerCodeFix_ClassEndWithCommandHandler()
    {
        const string test = @"
    using CommandHandlerAttributes;

    namespace ConsoleApplication1
    {
        class {|#0:TypeName|} : ICommandHandler
        {   
        }

        [CommandHandler]
        public interface ICommandHandler
        {
        }
    }";

        const string fixtest = @"
    using CommandHandlerAttributes;

    namespace ConsoleApplication1
    {
        class TypeNameCommandHandler : ICommandHandler
        {   
        }

        [CommandHandler]
        public interface ICommandHandler
        {
        }
    }";

        var expected = VerifyCS
            .Diagnostic(Rules.NameEndsWithCommandHandlerRule)
            .WithLocation(0)
            .WithArguments("TypeName");

        await VerifyCS.VerifyCodeFixAsync(test, expected, fixtest);
    }
}