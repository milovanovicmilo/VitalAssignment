using System.Windows.Input;
using Assignment.Application.TodoItems.Commands.CreateTodoItem;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.Domain.Enums;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI;

public class TodoItemViewModel : Screen
{
    private readonly ISender _sender;

    private TodoItemDto _currentItem;
    public TodoItemDto CurrentItem
    {
        get => _currentItem;
        set
        {
            _currentItem = value;
            NotifyOfPropertyChange(() => CurrentItem);
        }
    }

    public Dictionary<PriorityLevel, string> Priorities { get; set; } = [];

    public ICommand SaveCommand { get; }
    public ICommand CloseCommand { get; }

    public TodoItemViewModel(ISender sender, int listId)
    {
        _sender = sender;

        CurrentItem = new TodoItemDto() { ListId = listId };
        SaveCommand = new RelayCommand(SaveExecute);
        CloseCommand = new RelayCommand(CloseExecute);

        FillPriorities();
    }

    private void FillPriorities()
    {
        foreach (var value in Enum.GetValues(typeof(PriorityLevel)))
        {
            Priorities.Add((PriorityLevel)value, value.ToString());
        }
    }

    private async void SaveExecute(object parameter)
    {
        await _sender.Send(new CreateTodoItemCommand
        {
            ListId = CurrentItem.ListId,
            Title = CurrentItem.Title,
            Note = CurrentItem.Note,
            Priority = CurrentItem.Priority
        });
        await TryCloseAsync(true);
    }

    private async void CloseExecute(object parameter)
    {
        await TryCloseAsync(false);
    }
}
