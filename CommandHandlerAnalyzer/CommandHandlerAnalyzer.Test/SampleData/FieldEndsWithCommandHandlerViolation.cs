using CommandHandlerAttributes;

namespace PropertyEndWithCommandHandler;

internal class Class1
{
    private ICommandHandler property1;
}

[CommandHandler]
public interface ICommandHandler
{
}