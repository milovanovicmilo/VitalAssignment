﻿using System.ComponentModel;
using System.Windows.Input;
using Assignment.Application.TodoLists.Commands.CreateTodoList;
using Caliburn.Micro;
using MediatR;

namespace Assignment.UI;
public class TodoListViewModel : Screen
{
    private readonly ISender _sender;

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

    public TodoListViewModel(ISender sender)
    {
        _sender = sender;

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
        // TODO: Can we use ValidationBehavior here?
        if (value.Length > 200)
        {
            throw new ArgumentException("Title should be longer than 200.");
        }
    }
}
