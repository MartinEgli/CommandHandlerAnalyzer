using System.ComponentModel;
using System.Runtime.CompilerServices;
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

public class TestClass5 : INotifyPropertyChanged
{
    private ICommandHandler<bool> _property1;
    private ICommandHandler<bool> _property2CommandHandler;
    private ICommandHandler<bool> commandHandler;
    private ICommandHandler<bool> _commandHandler;
    private bool _property3CommandHandler;

    public ICommandHandler<bool> Property1

    {
        get => _property1;
        set => SetField(ref _property1, value);
    }

    public ICommandHandler<bool> Property2CommandHandler
    {
        get => _property2CommandHandler;
        set => SetField(ref _property2CommandHandler, value);
    }

    public bool Property3CommandHandler
    {
        get => _property3CommandHandler;
        set => SetField(ref _property3CommandHandler, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    private void Method1(ICommandHandler<bool> parameter1)
    {
        var x = parameter1;
    }

    private void Method2(ICommandHandler<bool> parameter1)
    {
        var commandHandler = parameter1;
    }

    private void Method3(ICommandHandler<bool> parameter1)
    {
        var xCommandHandler = parameter1;
    }


    private void Method4(bool parameter1CommandHandler)
    {
        var x = parameter1CommandHandler;
    }

    private void Method5(string parameter)
    {
        var xCommandHandler = parameter;
    }
}