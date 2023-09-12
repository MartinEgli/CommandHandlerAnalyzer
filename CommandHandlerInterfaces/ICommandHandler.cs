using CommandHandlerAttributes;

namespace CommandHandlerInterfaces;

[CommandHandler]
public interface ICommandHandler
{
}


public interface ICommandHandler<T> : ICommandHandler
{
}

public interface ICommandHandler<T1, T2> : ICommandHandler
{
}