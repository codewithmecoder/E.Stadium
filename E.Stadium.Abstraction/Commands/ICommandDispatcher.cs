namespace E.Stadium.Abstraction.Commands;

public interface ICommandDispatcher
{
    Task PerformAsync<TCommand>(TCommand command) where TCommand : class, ICommand;
}
