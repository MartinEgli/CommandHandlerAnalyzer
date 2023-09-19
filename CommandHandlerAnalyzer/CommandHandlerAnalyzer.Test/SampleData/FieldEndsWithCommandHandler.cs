using CommandHandlerAttributes;

namespace PropertyEndWithCommandHandler;

internal class Class1
{
    private ICommandHandler property1CommandHandler;
    private ICommandHandler commandHandler;
    private ICommandHandler _commandHandler;
}

[CommandHandler]
public interface ICommandHandler
{
}