using CommandHandlerAttributes;

namespace PropertyEndNotWithCommandHandler;

internal class Class1
{
    public void Methode(bool parameter1CommandHandler)
    {
    }
}

[CommandHandler]
public interface ICommandHandler
{
}