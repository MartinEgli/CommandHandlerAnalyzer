using CommandHandlerInterfaces;

namespace CommandHandlerSample;

[CommandHandler]
public class TestClass1 : ICommandHandler<bool>
{
}

public class TestClass2 : ICommandHandler<bool>
{
}

public class TestClass3
{
}

public class TestClass4CommandHandler
{
}