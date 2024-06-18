using System.ComponentModel;
using System.Windows.Input;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Caliburn.Micro;
using FluentValidation;
using MediatR;

namespace Assignment.UI;
public class TodoListViewModel : Screen
{
    private readonly ISender _sender;
    private readonly IValidator _validator;

    private string _title;
    public string Title
    {
        get => _title;
        set
        {
            ValidateInputData(value);
            _title = value;
            NotifyOfPropertyChange(() => Title);
        }
    }

    public ICommand SaveCommand { get; }
    public ICommand CloseCommand { get; }

    public TodoListViewModel(ISender sender, IValidator validator)
    {
        _sender = sender;
        _validator = validator;

        SaveCommand = new RelayCommand(SaveExecute);
        CloseCommand = new RelayCommand(CloseExecute);
    }

    private async void SaveExecute(object parameter)
    {
        await _sender.Send(new CreateTodoListCommand(Title));
        await TryCloseAsync(true);
    }

    private async void CloseExecute(object parameter)
    {
        await TryCloseAsync(false);
    }
    private void ValidateInputData(string value)
    {
        var command = new CreateTodoListCommand(value);
        var validationContext = new ValidationContext<CreateTodoListCommand>(command)
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
