using CommandHandlerAttributes;

namespace PropertyEndWithCommandHandler;

internal class Class1
{
    public ICommandHandler Property1 { get; set; }
}

[CommandHandler]
public interface ICommandHandler
{
}