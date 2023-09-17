using CommandHandlerAttributes;

namespace PropertyEndWithCommandHandler;

internal class Class1
{
    public void Methode(ICommandHandler parameter1)
    {
    }
}

[CommandHandler]
public interface ICommandHandler
{
}