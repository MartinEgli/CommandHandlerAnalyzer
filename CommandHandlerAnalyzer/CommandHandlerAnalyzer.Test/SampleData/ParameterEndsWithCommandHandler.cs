﻿using CommandHandlerAttributes;

namespace PropertyEndWithCommandHandler;

internal class Class1
{
    public void Methode(ICommandHandler parameter1CommandHandler, ICommandHandler commandHandler)
    {
    }
}

[CommandHandler]
public interface ICommandHandler
{
}