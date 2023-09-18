using CommandHandlerAttributes;

namespace PropertyEndWithCommandHandler;

public class Class1
{
    public void Method1()
    {
        var test = new ClassCommandHandler();
    }
}

public class ClassCommandHandler : ICommandHandler
{
}

[CommandHandler]
public interface ICommandHandler
{
}