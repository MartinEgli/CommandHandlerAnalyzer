using CommandHandlerAttributes;

namespace PropertyEndWithCommandHandler;

internal class Class1
{
    public ICommandHandler Property1CommandHandler { get; set; }
    public ICommandHandler CommandHandler { get; set; }
}

[CommandHandler]
public interface ICommandHandler
{
}