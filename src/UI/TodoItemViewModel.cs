using System.Windows.Input;
using Assignment.Application.TodoItems.Commands.CreateTodoItem;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Assignment.Application.TodoLists.Queries.GetTodos;
using Assignment.Domain.Enums;
using Caliburn.Micro;
using FluentValidation;
using MediatR;

namespace Assignment.UI;

public class TodoItemViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IValidator _validator;

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

    private string _title;
    public string Title
    {
        get {  return _title; }
        set
        {
            ValidateInputData(value);
            _title = value;
            NotifyOfPropertyChange(() => Title);
        }
    }

    public Dictionary<PriorityLevel, string> Priorities { get; set; } = [];

    public ICommand SaveCommand { get; }
    public ICommand CloseCommand { get; }

    public TodoItemViewModel(ISender sender, IValidator validator, int listId)
    {
        _sender = sender;
        _validator = validator;

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
            Title = Title,
            Note = CurrentItem.Note,
            Priority = CurrentItem.Priority
        });
        await TryCloseAsync(true);
    }

    private async void CloseExecute(object parameter)
    {
        await TryCloseAsync(false);
    }
    private void ValidateInputData(string value)
    {
        var command = new CreateTodoItemCommand()
        {
            ListId = (int)CurrentItem?.ListId,
            Title = value,
            Note = CurrentItem?.Note,
            Priority = (PriorityLevel)CurrentItem?.Priority
        };
        var validationContext = new ValidationContext<CreateTodoItemCommand>(command)
        {
            RootContextData =
        {
            ["Title"] = value,
        }
        };

        var validationResult = _validator.ValidateAsync(validationContext);

        if (validationResult != null && validationResult.Result != null && !validationResult.Result.IsValid)
        {
            throw new ValidationException(validationResult.Result.ToString());
        }
    }
}
